drop table if exists Roles;
create table Roles(
	Id UUID PRIMARY KEY,
	Name VARCHAR(20)
);

drop table if exists Users;
create table Users(
	Id UUID PRIMARY KEY,
	Username VARCHAR(20),
	Password CHAR(64),
	Age INT,
	RoleId UUID,
	FOREIGN KEY (RoleId) REFERENCES Roles (Id) ON DELETE SET NULL
);

drop table if exists Chats;
create table Chats(
	Id UUID PRIMARY KEY,
	Name VARCHAR(100)
);

drop table if exists ChatMessages;
create table ChatMessages(
	Id UUID PRIMARY KEY,
	AuthorId UUID NOT NULL,
	ChatId UUID NOT NULL,
	Value VARCHAR(100),
	FOREIGN KEY (ChatId) REFERENCES Chats (Id) ON DELETE CASCADE,
	FOREIGN KEY (AuthorId) REFERENCES Users (Id) ON DELETE CASCADE
);


insert into Roles (Id, Name) values ('cdbd1375-0894-4801-86db-b23ca5bb7783', 'admin');
insert into Roles (Id, Name) values ('9cbce4df-2d9b-42b6-90a3-1e01eac4eb7a', 'guest');

insert into Users (Id, Username, Password, Age, RoleId) values ('53b7aead-1aaf-422b-a8ac-5befe13210ba', 'admin', 'admin', 17, 'cdbd1375-0894-4801-86db-b23ca5bb7783');
insert into Users (Id, Username, Password, Age, RoleId) values ('6806ee86-f1d2-4a13-94ae-83e8b71373bd', 'guest', 'guset', 19, '9cbce4df-2d9b-42b6-90a3-1e01eac4eb7a');

insert into Chats (Id, Name) values ('758bd9be-889d-4742-9602-976a186da7d1', 'Lohi');
insert into Chats (Id, Name) values ('ac55136c-b565-450c-8a59-97cee7acd7fe', 'gayniggersfromouterspace');
insert into Chats (Id, Name) values ('5069fae4-619d-4466-8d0d-05d6d4fcaa2d', 'secret_group');
insert into Chats (Id, Name) values ('38c69f4a-6be7-4884-9dea-775b6968cd4d', 'AMONGUS SRP 18+');
insert into Chats (Id, Name) values ('b2e199eb-a69b-40f3-ab7e-341ef7e3a728', 'CTF2k23');

insert into ChatMessages(Id, ChatId, AuthorId, Value) values
	(gen_random_uuid(), '758bd9be-889d-4742-9602-976a186da7d1', '53b7aead-1aaf-422b-a8ac-5befe13210ba', 'i hate niggers'),
	(gen_random_uuid(), '758bd9be-889d-4742-9602-976a186da7d1', '6806ee86-f1d2-4a13-94ae-83e8b71373bd', 'i nate higgers'),
	(gen_random_uuid(), '38c69f4a-6be7-4884-9dea-775b6968cd4d', '6806ee86-f1d2-4a13-94ae-83e8b71373bd', 'uwu daddy im so horny ~~~'),
	(gen_random_uuid(), '38c69f4a-6be7-4884-9dea-775b6968cd4d', '53b7aead-1aaf-422b-a8ac-5befe13210ba', 'kill yourself'),
	(gen_random_uuid(), '758bd9be-889d-4742-9602-976a186da7d1', '53b7aead-1aaf-422b-a8ac-5befe13210ba', 'i hate niggers');
