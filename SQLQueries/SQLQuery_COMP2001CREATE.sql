CREATE TABLE dbo.Users(
    userid INT NOT NULL,
    firstName VARCHAR(24) NOT NULL,
    lastName VARCHAR(24) NOT NULL,
    email VARCHAR(254) NOT NULL,
    password VARCHAR(36) NOT NULL,
    CONSTRAINT PK_user PRIMARY KEY (userid)
)

CREATE TABLE dbo.Passwords(
    userid INT NOT NULL,
    password_modified_date_time DATETIME NOT NULL,
    password VARCHAR(24) NOT NULL,
    CONSTRAINT PK_password PRIMARY KEY (userid, password_modified_date_time)
)

CREATE TABLE dbo.Sessions(
    userid INT NOT NULL,
    date_time_recorded DATETIME NOT NULL,
    CONSTRAINT PK_session PRIMARY KEY (userid, date_time_recorded)
)
