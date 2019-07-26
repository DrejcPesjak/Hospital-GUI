USE [Bolnisnica]
GO

CREATE VIEW [dbo].[View_Login]
AS
SELECT        uporabnisko_ime, geslo, EMSO_pacienta, EMSO_doktorja, EMSO_sestre
FROM            dbo.Uporabnik

GO

CREATE VIEW [dbo].[View_Pacient]
AS
SELECT        dbo.Pacient.*, dbo.Posta.kraj
FROM            dbo.Pacient INNER JOIN
                         dbo.Posta ON dbo.Pacient.postna_st = dbo.Posta.postna_st

GO
USE [Bolnisnica]
GO



CREATE VIEW [dbo].[View_TerminRecept]
AS
SELECT        dbo.Termin.EMSO_pacienta, dbo.Pacient.ime AS ime_pacienta, dbo.Pacient.priimek AS priimek_pacienta, dbo.Pacient.naslov AS naslov_pacienta, dbo.Pacient.postna_st AS posta_pacienta, 
                         dbo.Posta.kraj AS kraj_pacienta, dbo.Termin.EMSO_doktorja, dbo.Doktor.ime AS ime_doktorja, dbo.Doktor.priimek AS priimek_doktorja, dbo.Doktor.[e-posta] AS [e-posta_doktorja], 
                         dbo.Doktor.telefon AS telefon_doktorja, dbo.Doktor.naslov AS naslov_doktorja, dbo.Doktor.postna_st AS posta_doktorja, Posta_1.kraj AS kraj_doktor, dbo.Termin.sifra_termina, dbo.Termin.datum, dbo.Termin.opis, 
                         dbo.Recept.sifra_recepta, dbo.Recept.razlog, dbo.Recept.nacin, dbo.Recept.drzava, dbo.Recept.enotaZZZS, dbo.Recept.vrsta_doktorja, dbo.Recept_zdravilo.sifra_zdravila, dbo.Recept_zdravilo.kolicina
FROM            dbo.Recept INNER JOIN
                         dbo.Recept_zdravilo ON dbo.Recept.sifra_recepta = dbo.Recept_zdravilo.sifra_recepta INNER JOIN
                         dbo.Termin ON dbo.Recept.sifra_termina = dbo.Termin.sifra_termina AND dbo.Recept.EMSO_pacienta = dbo.Termin.EMSO_pacienta INNER JOIN
                         dbo.Doktor ON dbo.Termin.EMSO_doktorja = dbo.Doktor.EMSO_doktorja INNER JOIN
                         dbo.Pacient ON dbo.Termin.EMSO_pacienta = dbo.Pacient.EMSO_pacienta INNER JOIN
                         dbo.Posta ON dbo.Pacient.postna_st = dbo.Posta.postna_st INNER JOIN
                         dbo.Posta AS Posta_1 ON dbo.Doktor.postna_st = Posta_1.postna_st

GO
---------------admin procedure--------------------
CREATE PROCEDURE sp_dodaj_uporabnika 
@uporabnisko_ime nvarchar(40),
@geslo nvarchar(80),
@pacient char(13),
@doktor char(13),
@sestra char(13)
AS
BEGIN
	INSERT INTO Uporabnik(uporabnisko_ime, geslo, EMSO_pacienta, EMSO_doktorja, EMSO_sestre)
	VALUES (@uporabnisko_ime, @geslo, @pacient, @doktor, @sestra)
END
GO

CREATE PROCEDURE sp_ponastavi_geslo
@uporabnisko_ime nvarchar(40)
AS
BEGIN
	DECLARE @sifra INT = 0; DECLARE @EMSO Char(13); DECLARE @EMSO_pac Char(13); DECLARE @EMSO_ses Char(13);

	SELECT @sifra=sifra_uporabnika, @EMSO = EMSO_doktorja, @EMSO_pac = EMSO_pacienta, @EMSO_ses = EMSO_sestre
	FROM Uporabnik
	WHERE uporabnisko_ime=@uporabnisko_ime

	IF @EMSO_ses <> ''
	BEGIN 
		SET @EMSO = @EMSO_ses
	END
	ELSE IF @EMSO_pac <> ''
	BEGIN
		SET @EMSO = @EMSO_pac
	END
	
	IF @sifra <> 0
	BEGIN
		UPDATE UPORABNIK
		SET geslo= CONVERT(varchar(64),HASHBYTES('SHA2_256', @EMSO),2)
		WHERE sifra_uporabnika=@sifra 
	END
END
go

CREATE PROCEDURE sp_dodaj_doktorja
@EMSO_doktorja Char(13),
@ime Nvarchar(50),
@priimek Nvarchar(50),
@status Varchar(9),
@naslov Nvarchar(100),
@placa_bruto Money,
@specializacija Nvarchar(50),
@postna_st Char(4)
AS
BEGIN
	INSERT INTO [dbo].[Doktor]([EMSO_doktorja],[ime],[priimek],[status],[naslov],[placa_bruto],[specializacija],[postna_st])
    VALUES (@EMSO_doktorja, @ime, @priimek, @status, @naslov, @placa_bruto, @specializacija, @postna_st)
END
GO

CREATE PROCEDURE sp_dodaj_sestro
@EMSO_sestre Char(13),
@ime Nvarchar(50),
@priimek Nvarchar(50),
@placa_bruto Money,
@naslov Nvarchar(100),
@postna_st Char(4)
AS
BEGIN
	INSERT INTO [dbo].[Sestra]([EMSO_sestre],[ime],[priimek],[naslov],[placa_bruto],[postna_st])
    VALUES (@EMSO_sestre, @ime, @priimek, @naslov, @placa_bruto, @postna_st)
END
GO

--VSI uporabniki--
CREATE PROCEDURE sp_spremeni_geslo
@uporabnisko_ime Nvarchar(40),
@geslo_staro Nvarchar(80),
@geslo_novo Nvarchar(80)
AS
BEGIN
	DECLARE @sifra INT = 0;

	SELECT @sifra=sifra_uporabnika
	FROM Uporabnik
	WHERE uporabnisko_ime=@uporabnisko_ime AND
		  geslo = @geslo_staro

	IF @sifra <> 0
	BEGIN
		UPDATE UPORABNIK
		SET geslo=@geslo_novo
		WHERE sifra_uporabnika=@sifra 
	END
END
GO

--SESTRA procedure--
CREATE PROCEDURE sp_dodaj_pacienta 
@EMSO_pacienta char(13),
@ime nvarchar(50),
@priimek nvarchar(50),
@naslov nvarchar(100),
@postna_st char(4),
@telefon nchar(11) = NULL,
@sifra_sobe int = NULL
AS
BEGIN
	INSERT INTO Pacient
	VALUES (@EMSO_pacienta ,@ime ,	@priimek,	@telefon ,	@naslov ,	@postna_st ,	@sifra_sobe )
END
GO
/*EXEC sp_dodaj_pacienta '1234567891123','drejc','pesjak', 'gregorčičeva 4', '2000'
EXEC sp_dodaj_pacienta '1234567891123','drejc','pesjak', 'gregorčičeva 4', '2000',null , NULL
EXEC sp_dodaj_pacienta @EMSO_pacienta='1234567891123',@ime='drejc',@priimek='pesjak',@naslov='gregorčičeva 4',@postna_st='2000'*/

CREATE PROCEDURE sp_spremeni_pacienta 
@EMSO_pacienta char(13),
@ime nvarchar(50),
@priimek nvarchar(50),
@naslov nvarchar(100),
@postna_st char(4),
@telefon nchar(11) = NULL,
@sifra_sobe int = NULL
AS
BEGIN
	UPDATE Pacient
	SET ime=@ime, priimek=@priimek, telefon=@telefon, naslov=@naslov, postna_st=@postna_st, sifra_sobe=@sifra_sobe
	WHERE EMSO_pacienta = @EMSO_pacienta
END
GO

--DOKTOR procedure--
CREATE PROCEDURE sp_dodaj_termin
@EMSO_pacienta char(13),
@datum datetime,
@opis nvarchar(MAX),
@EMSO_doktorja char(13)
AS
BEGIN
		INSERT INTO [dbo].[Termin]
		VALUES (@EMSO_pacienta, @datum, CAST(@opis AS TEXT), @EMSO_doktorja)

		RETURN @@IDENTITY
END
GO

CREATE PROCEDURE sp_dodaj_recept
@sifra_termina int,
@EMSO_pacienta char(13),
@razlog int,
@nacin int,
@vrsta_doktorja nvarchar(11),
@drzava char(3) = NULL,
@enotaZZZS char(6) = NULL
AS
BEGIN
		INSERT INTO [dbo].[Recept] (sifra_termina, EMSO_pacienta, razlog, nacin, vrsta_doktorja, drzava, enotaZZZS)
		VALUES (@sifra_termina, @EMSO_pacienta, @razlog, @nacin, @vrsta_doktorja, @drzava, @enotaZZZS)
END
GO

---------------TRIGGER---------------
--CONVERT(varchar(64),HASHBYTES('SHA2_256', 'gesloForAdmin999'),2)

CREATE TRIGGER tg_doktor
ON Doktor
FOR INSERT
AS
BEGIN
	DECLARE @EMSO_dok char(13)
	DECLARE @ime nvarchar(50)
	DECLARE @priimek nvarchar(50)

	SELECT @EMSO_dok = EMSO_doktorja, @ime = ime, @priimek = priimek
	FROM inserted
	
	--ime=Drejc ; priimek=Pesjak ; emso=1803999500136
	--upor.ime=DPesjak136 ; geslo=HASH(emso) ; emso_dok=1803999500136
	INSERT INTO Uporabnik (uporabnisko_ime, geslo, EMSO_doktorja)
	VALUES (LEFT(@ime,1)+@priimek+RIGHT(@EMSO_dok,3), CONVERT(varchar(64),HASHBYTES('SHA2_256', @EMSO_dok),2), @EMSO_dok)
END
GO


CREATE TRIGGER tg_pacient
ON Pacient
FOR INSERT
AS
BEGIN
	DECLARE @EMSO_pac char(13)
	DECLARE @ime nvarchar(50)
	DECLARE @priimek nvarchar(50)

	SELECT @EMSO_pac = EMSO_pacienta, @ime = ime, @priimek = priimek
	FROM inserted	
	
	INSERT INTO Uporabnik (uporabnisko_ime, geslo, EMSO_pacienta)
	VALUES (LEFT(@ime,1)+@priimek+RIGHT(@EMSO_pac,3), CONVERT(varchar(64),HASHBYTES('SHA2_256', @EMSO_pac),2), @EMSO_pac)
END
GO

CREATE TRIGGER tg_sestra
ON Sestra
FOR INSERT
AS
BEGIN
	DECLARE @EMSO_ses char(13)
	DECLARE @ime nvarchar(50)
	DECLARE @priimek nvarchar(50)

	SELECT @EMSO_ses = EMSO_sestre, @ime = ime, @priimek = priimek
	FROM inserted	
	
	INSERT INTO Uporabnik (uporabnisko_ime, geslo, EMSO_pacienta)
	VALUES (LEFT(@ime,1)+@priimek+RIGHT(@EMSO_ses,3), CONVERT(varchar(64),HASHBYTES('SHA2_256', @EMSO_ses),2), @EMSO_ses)
END
GO