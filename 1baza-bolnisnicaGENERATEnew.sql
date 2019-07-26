/*
Created		29-Apr-18
Modified		29-Apr-18
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2000 
*/


/*
Drop index [dbo].[Posta].[IX_kraj] 
go
Drop index [dbo].[Recept].[IX_terminFK] 
go

Drop table [dbo].[Zdravilo] 
go
Drop table [dbo].[Uporabnik] 
go
Drop table [dbo].[Termin] 
go
Drop table [dbo].[Soba] 
go
Drop table [dbo].[Sestra] 
go
Drop table [dbo].[Recept_zdravilo] 
go
Drop table [dbo].[Recept] 
go
Drop table [dbo].[Posta] 
go
Drop table [dbo].[Pacient] 
go
Drop table [dbo].[Doktor] 
go

*/


Create database Bolnisnica
go

Use Bolnisnica
go


Create table [dbo].[Doktor]
(
	[EMSO_doktorja] Char(13) NOT NULL,
	[ime] Nvarchar(50) NOT NULL,
	[priimek] Nvarchar(50) NOT NULL,
	[status] Varchar(9) NOT NULL Check(status='gostujoci' OR status='redni' OR status='vajenec'),
	[specializacija] Nvarchar(50) NULL,
	[telefon] Nchar(11) NULL, UNIQUE ([telefon]),
	[e-posta] Nvarchar(75) NULL, UNIQUE ([e-posta]),
	[naslov] Nvarchar(100) NULL,
	[placa_bruto] Money NOT NULL Check(placa_bruto>0),
	[postna_st] Char(4) NOT NULL,
Primary Key ([EMSO_doktorja])
) 
go

Create table [dbo].[Pacient]
(
	[EMSO_pacienta] Char(13) NOT NULL,
	[ime] Nvarchar(50) NOT NULL,
	[priimek] Nvarchar(50) NOT NULL,
	[telefon] Nchar(11) NULL,
	[naslov] Nvarchar(100) NOT NULL,
	[postna_st] Char(4) NOT NULL,
	[sifra_sobe] Integer NULL,
Primary Key ([EMSO_pacienta])
) 
go

Create table [dbo].[Posta]
(
	[postna_st] Char(4) NOT NULL,
	[kraj] Nvarchar(50) NOT NULL,
Primary Key ([postna_st])
) 
go

Create table [dbo].[Recept]
(
	[sifra_recepta] Integer Identity(0,1) NOT NULL,
	[razlog] Integer NOT NULL Check (razlog<6),
	[nacin] Integer NOT NULL Check (nacin<4),
	[drzava] Char(3) NULL,
	[enotaZZZS] Char(6) NULL,
	[vrsta_doktorja] Nvarchar(11) NOT NULL Check (vrsta_doktorja = 'osebni' OR vrsta_doktorja='pooblasceni' OR vrsta_doktorja='nadomestni'),
	[sifra_termina] Integer NOT NULL,
	[EMSO_pacienta] Char(13) NOT NULL,
Primary Key ([sifra_recepta])
) 
go

Create table [dbo].[Recept_zdravilo]
(
	[sifra_recepta] Integer NOT NULL,
	[sifra_zdravila] Integer NOT NULL,
	[kolicina] Integer NOT NULL Check (kolicina>0),
Primary Key ([sifra_recepta],[sifra_zdravila])
) 
go

Create table [dbo].[Sestra]
(
	[EMSO_sestre] Char(13) NOT NULL,
	[ime] Nvarchar(50) NOT NULL,
	[priimek] Nvarchar(50) NOT NULL,
	[placa_bruto] Money NOT NULL Check(placa_bruto>0),
	[naslov] Nvarchar(100) NULL,
	[postna_st] Char(4) NOT NULL,
Primary Key ([EMSO_sestre])
) 
go

Create table [dbo].[Soba]
(
	[sifra_sobe] Integer Identity(0,1) NOT NULL,
	[st_nadstropja] Integer NOT NULL Check(st_nadstropja>=0),
	[st_postelj] Integer NOT NULL Check(st_postelj>0),
	[EMSO_sestre] Char(13) NOT NULL,
Primary Key ([sifra_sobe])
) 
go

Create table [dbo].[Termin]
(
	[sifra_termina] Integer Identity(0,1) NOT NULL,
	[EMSO_pacienta] Char(13) NOT NULL,
	[datum] Datetime NOT NULL Check (datum<GetDate()),
	[opis] Text NOT NULL,
	[EMSO_doktorja] Char(13) NOT NULL,
Primary Key ([sifra_termina],[EMSO_pacienta])
) 
go

Create table [dbo].[Uporabnik]
(
	[sifra_uporabnika] Integer Identity(0,1) NOT NULL,
	[uporabnisko_ime] Nvarchar(40) NOT NULL, UNIQUE ([uporabnisko_ime]),
	[geslo] Nvarchar(80) NOT NULL,
	[EMSO_pacienta] Char(13) NULL, 
	[EMSO_doktorja] Char(13) NULL, 
	[EMSO_sestre] Char(13) NULL,
Primary Key ([sifra_uporabnika])
) 
go

Create table [dbo].[Zdravilo]
(
	[sifra_zdravila] Integer Identity(0,1) NOT NULL,
	[ime] Nvarchar(50) NOT NULL,
	[opis] Text NOT NULL,
	[oblika] Char(10) NULL,
	[pakiranje] Decimal(5,2) NOT NULL Check(pakiranje>0),
	[cena] Money NOT NULL,
	[podjetje] Nvarchar(50) NOT NULL,
Primary Key ([sifra_zdravila])
) 
go



Alter table [dbo].[Pacient] add constraint [UQ__Pacient__237247E2D5E1D954] unique ([telefon])
go

Alter table [dbo].[Uporabnik] add constraint [UQ__Uporabni__D3564ABA737A5305] unique ([uporabnisko_ime])
go



Create Index [IX_kraj] ON [dbo].[Posta] ([kraj] ) 
go
Create Index [IX_terminFK] ON [dbo].[Recept] ([sifra_termina] Desc) 
go


Alter table [dbo].[Termin] add  foreign key([EMSO_doktorja]) references [dbo].[Doktor] ([EMSO_doktorja]) 
go
Alter table [dbo].[Uporabnik] add  foreign key([EMSO_doktorja]) references [dbo].[Doktor] ([EMSO_doktorja]) 
go
Alter table [dbo].[Termin] add  foreign key([EMSO_pacienta]) references [dbo].[Pacient] ([EMSO_pacienta]) 
go
Alter table [dbo].[Uporabnik] add  foreign key([EMSO_pacienta]) references [dbo].[Pacient] ([EMSO_pacienta])
go
Alter table [dbo].[Doktor] add  foreign key([postna_st]) references [dbo].[Posta] ([postna_st]) 
go
Alter table [dbo].[Pacient] add  foreign key([postna_st]) references [dbo].[Posta] ([postna_st])
go
Alter table [dbo].[Sestra] add  foreign key([postna_st]) references [dbo].[Posta] ([postna_st])
go
Alter table [dbo].[Recept_zdravilo] add  foreign key([sifra_recepta]) references [dbo].[Recept] ([sifra_recepta])
go
Alter table [dbo].[Soba] add  foreign key([EMSO_sestre]) references [dbo].[Sestra] ([EMSO_sestre])
go
Alter table [dbo].[Uporabnik] add  foreign key([EMSO_sestre]) references [dbo].[Sestra] ([EMSO_sestre])
go
Alter table [dbo].[Pacient] add  foreign key([sifra_sobe]) references [dbo].[Soba] ([sifra_sobe])
go
Alter table [dbo].[Recept] add  foreign key([sifra_termina],[EMSO_pacienta]) references [dbo].[Termin] ([sifra_termina],[EMSO_pacienta])
go
Alter table [dbo].[Recept_zdravilo] add  foreign key([sifra_zdravila]) references [dbo].[Zdravilo] ([sifra_zdravila])  on update cascade on delete cascade 
go
