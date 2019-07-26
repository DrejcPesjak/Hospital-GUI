USE Bolnisnica
GO

CREATE TRIGGER tg_increment_termin
ON Termin
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @sifra INT;
	DECLARE @EMSO_P CHAR(13);	DECLARE @EMSO_D CHAR(13);	DECLARE @datum DATETIME;	DECLARE @opis NVARCHAR(MAX);

	SELECT @EMSO_P=EMSO_pacienta, @EMSO_D=EMSO_doktorja, @datum=datum, @opis=CAST(opis AS nvarchar(MAX))
	FROM inserted

	SELECT @sifra = MAX(sifra_termina)+1
	FROM Termin
	WHERE EMSO_pacienta = @EMSO_P

	SET IDENTITY_INSERT dbo.Termin ON
	
	IF @sifra IS NULL
	BEGIN
		SET @sifra = 1;
	END

	INSERT INTO Termin(sifra_termina, EMSO_pacienta, datum, opis, EMSO_doktorja)
	VALUES (@sifra, @EMSO_P, @datum, CAST(@opis AS text), @EMSO_D)

	SET IDENTITY_INSERT dbo.Termin OFF
END