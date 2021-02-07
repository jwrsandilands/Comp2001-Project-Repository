CREATE PROCEDURE Register (@FirstName AS VARCHAR(24), @LastName AS VARCHAR(24), @Email AS VARCHAR(254), @Password AS VARCHAR(36), @ResponseMessage AS VARCHAR(MAX) OUTPUT) AS
    BEGIN
        BEGIN TRANSACTION
            -- Here, a new user record will be added to the Users table.
            -- After, a message is built and used as an output parameter.
            -- The message contains HTTP Status number and User ID from the entry.

            -- Variables
            DECLARE @newID AS INT;
            DECLARE @emailUnique AS VARCHAR(256);

            -- Check all current emails for a match
            SELECT @emailUnique = dbo.Users.email FROM dbo.Users WHERE @Email = dbo.Users.email;

            -- Create New ID
            SELECT @newID = MAX(dbo.Users.userid) FROM dbo.Users;
            SET @newID = @newID +1;

            -- Insert Values
            BEGIN TRY
                BEGIN TRANSACTION;
                INSERT INTO dbo.Users (userid, firstName, lastName, email, password)
                VALUES (@newID, @FirstName, @LastName, @Email, @Password);
                
                -- Set response message
                IF (@Email = @emailUnique)
                SET @ResponseMessage = '208';
                ELSE
                SET @ResponseMessage = '200' + CAST (@newID AS VARCHAR(32));
                COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                SET @ResponseMessage = '404'
                ROLLBACK TRANSACTION;
            END CATCH

            -- Enforce email match error
            IF (@Email = @emailUnique)
            ROLLBACK TRANSACTION;
            ELSE
            COMMIT;
    END;
GO

CREATE PROCEDURE ValidateUser (@Email AS VARCHAR(254), @Password AS VARCHAR(36)) AS
    BEGIN
        BEGIN TRANSACTION
            -- This checks if the input user and password matches the database.
            -- Should accomodate for the possibility of future outputs for different errors.
            -- If there is a match (1), it should update the sessions table.

            -- Variables
            DECLARE @emCheck AS VARCHAR(254);
            DECLARE @pwCheck AS VARCHAR(36);
            DECLARE @Validated AS INT;
            DECLARE @id AS INT;

            -- It returns a boolean 1 or 0 for a match or a mismatch.

            -- Check if login info valid
            SELECT @id = dbo.Users.userid FROM dbo.Users WHERE @Email = dbo.Users.email AND @Password = dbo.Users.password
            
            IF(@id != '')
            SET @Validated = 1;
            ELSE 
            SET @Validated = 0;

            -- update sessions table.
            IF(@id != '')
            INSERT INTO dbo.Sessions (userid, date_time_recorded)
            VALUES (@id, GETDATE()) 

            -- Return match number (May include more than 0 or 1 in future)
            COMMIT;
            RETURN @Validated;
    END;
GO

CREATE PROCEDURE UpdateUser (@FirstName AS VARCHAR(24), @LastName AS VARCHAR(24), @Email AS VARCHAR(254), @Password AS VARCHAR(36), @id AS INT) AS
    BEGIN
        BEGIN TRANSACTION
            -- Updates the old record for the newly input ones.
            -- NOTE: if a value is null please do not replace the old values with the null value.

            -- Variables
            DECLARE @oldFirstName AS VARCHAR(24);
            DECLARE @oldLastName AS VARCHAR(24);
            DECLARE @oldEmail AS VARCHAR(254);
            DECLARE @oldPassword AS VARCHAR(36);

            -- Get Current Values for the User
            SELECT @oldFirstName = dbo.Users.firstName FROM dbo.Users WHERE dbo.Users.userid = @id;
            SELECT @oldLastName = dbo.Users.lastName FROM dbo.Users WHERE dbo.Users.userid = @id;
            SELECT @oldEmail = dbo.Users.email FROM dbo.Users WHERE dbo.Users.userid = @id;
            SELECT @oldPassword = dbo.Users.password FROM dbo.Users WHERE dbo.Users.userid = @id;

            -- Update data fields if they are not null.
            IF(@FirstName = '')
            SET @FirstName = @oldFirstName;
            IF(@LastName = '')
            SET @LastName = @oldLastName;
            IF(@Email = '')
            SET @Email = @oldEmail
            IF(@Password = '')
            SET @Password = @oldPassword

            UPDATE dbo.Users SET dbo.Users.firstName = @FirstName, dbo.Users.lastName = @LastName, dbo.Users.email = @Email, dbo.Users.[password] = @Password WHERE dbo.Users.userid = @id;

            IF(@id = null)
            ROLLBACK;

            ELSE
            COMMIT;
    END;
GO

CREATE PROCEDURE DeleteUser (@id AS INT) AS
    BEGIN
        BEGIN TRANSACTION
            -- Deletes the user record at the user ID.

            -- Delete stored Passwords
            DELETE FROM dbo.Passwords WHERE @id = dbo.Passwords.userid;

            -- Delete Session Data
            DELETE FROM dbo.Sessions Where @id = dbo.Sessions.userid;

            -- Delete User
            DELETE FROM dbo.Users WHERE @id = dbo.Users.userid;

            IF(@id = null)
            ROLLBACK;
            ELSE
            COMMIT;
    END;
GO
