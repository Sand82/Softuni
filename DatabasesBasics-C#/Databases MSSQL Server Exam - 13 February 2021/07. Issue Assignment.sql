SELECT 
	i.Id,
	CONCAT(u.Username,' ', ':',' ', i.Title) AS IssueAssignee
FROM Issues AS i 
JOIN Users As u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, u.Username