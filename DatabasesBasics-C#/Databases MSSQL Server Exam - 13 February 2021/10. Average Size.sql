SELECT 
	u.Username,
	AVG(f.Size) AS Size
FROM Users AS u
LEFT JOIN Commits As c ON u.Id = c.ContributorId
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC,u.Username

