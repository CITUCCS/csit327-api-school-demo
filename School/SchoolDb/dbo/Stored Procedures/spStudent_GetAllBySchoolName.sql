CREATE PROC spStudent_GetAllBySchoolName 
	@schoolName nvarchar(50)
AS
BEGIN 
	DECLARE @schoolId INT;

	SET @schoolId = (
		SELECT Id FROM School WHERE Name = @schoolName
	);

	SELECT 
		* 
	FROM 
		Student 
	WHERE 
		SchoolId = @schoolId;
END