CREATE PROC spStudent_GetAllBySchoolId 
	@schoolId INT
AS
BEGIN
	SELECT 
		* 
	FROM
		Student 
	WHERE 
		SchoolId = @schoolId;
END