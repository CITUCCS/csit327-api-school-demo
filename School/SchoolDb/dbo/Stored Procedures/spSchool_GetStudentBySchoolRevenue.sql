CREATE PROC spSchool_GetStudentBySchoolRevenue(
	@schoolId INT = 0
	,@minSchoolRevenue INT
)
AS 

DECLARE @counter INT = 1;

WHILE @counter <= 4

BEGIN 

	SET @schoolId = @counter;

	DECLARE @avgTution DECIMAL = (
		SELECT AverageTuition FROM School WHERE Id=@schoolId
	);

	DECLARE @schoolRevenue DECIMAL = (
		SELECT COUNT(*) * @avgTution FROM Student WHERE SchoolId = @schoolId
	);

	IF @schoolRevenue > @minSchoolRevenue

	BEGIN 
		SELECT * FROM Student WHERE @schoolRevenue > @minSchoolRevenue;
	END

	SET @counter = @counter + 1;

END