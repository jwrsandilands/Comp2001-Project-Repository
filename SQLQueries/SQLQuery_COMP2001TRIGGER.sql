CREATE TRIGGER StorePassword ON dbo.Users
    AFTER UPDATE
        AS 
        BEGIN
            SET NOCOUNT ON;
            -- This saves the previously input password when updated by a user.

            -- Variables
            DECLARE @oldPw AS VARCHAR(36);
            DECLARE @newPw AS VARCHAR(36);
            DECLARE @id AS INT;
            
            -- Get variables from the virtual deleted table
            SELECT @id = deleted.userid FROM DELETED;
            SELECT @oldPw = deleted.password FROM DELETED;
            SELECT @newPw = dbo.Users.password FROM dbo.Users WHERE dbo.Users.userid = @id;

            -- insert info
            IF(@oldPw != @newPw)
            INSERT INTO dbo.Passwords (userid, password_modified_date_time, password)
            VALUES (@id, GETDATE(), @oldPw);
    END;
GO
