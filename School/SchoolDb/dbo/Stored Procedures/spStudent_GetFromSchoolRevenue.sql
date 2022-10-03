CREATE PROC spStudent_GetFromSchoolRevenue
 @revenue DECIMAL
AS
BEGIN 

DECLARE @sId INT;
DECLARE @avgTution DECIMAl;
DECLARE @count INT;

SET @sId = 1;



WHILE @sId < 5
BEGIN 
	SET @avgTution = (
		SELECT AverageTuition FROM School WHERE Id=@sId
	);

	SET @count = (
		SELECT COUNT(*) FROM Student WHERE SchoolId = @sId
	);

	IF (@avgTution * @count) > @revenue
	BEGIN
		SELECT * FROM Student WHERE SchoolId = @sId;
	END
	SET @sId = @sId + 1;
END

END