CREATE PROC spStudent_GetAllBySchoolId 
	@schoolId INT
AS
BEGIN
	SELECT 
		* 
	FROM
		Student AS S
	INNER JOIN 
		School AS SC
	ON S.SchoolId = SC.Id
	WHERE 
		S.SchoolId = @schoolId;
END