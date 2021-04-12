--CREATE DATABASE KunderIBio;

Drop table Biografbillet;
Drop table Kunde;

Create table Kunde(
navn varchar(40) NOT NULL,
tlfNr varchar(12) NOT NULL
primary key(tlfNr));


Create table Biografbillet(
filmnavn varchar(40) NOT NULL,
dato Date NOT NULL,
tid Time NOT NULL,
sæderække INT NOT NULL,
stolenummer INT NOT NULL,
kundeNr varchar(12) NOT NULL,
id int NOT NULL,
foreign key (kundeNr) references Kunde(tlfNr),
primary key(id));


Insert into Kunde(navn,tlfNr)
values('Ole Mark', '88888881');


Insert into Kunde(navn,tlfNr)
values('Oliver Wisborg', '99999991');


Insert into Biografbillet(filmnavn,dato,tid,sæderække,stolenummer,kundeNr,id)
values('Gladiator','2020-05-22','12:55:22',5,5, '99999991', 1);


Insert into Biografbillet(filmnavn,dato,tid,sæderække,stolenummer,kundeNr,id)
values('Gladiator','2020-05-22','12:55:22',5,6, '88888881', 2);