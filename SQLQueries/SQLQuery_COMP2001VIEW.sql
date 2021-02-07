CREATE VIEW "UserSessions" AS
    SELECT dbo.Sessions.userid, count(*) AS "Total_Times_Logged_In" 
    FROM dbo.Sessions 
    GROUP BY userid;