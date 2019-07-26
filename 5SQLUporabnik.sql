CREATE LOGIN gui_user_bolnisnica 
WITH PASSWORD = 'holyPass666'
go

USE Bolnisnica
go

CREATE USER uporabnik
FOR LOGIN gui_user_bolnisnica
go

GRANT SELECT ON View_Login TO uporabnik;
GRANT SELECT ON View_Pacient TO uporabnik;
GRANT SELECT ON View_TerminRecept TO uporabnik;

GRANT EXEC TO uporabnik;