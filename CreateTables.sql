CREATE TABLE Theater {
        TheaterID int primary key,
        Name varchar(255),
        State varchar(255),
        City varchar(255),
        StreetNumber varchar(255),
        Street varchar(255),
        Zip char(5),
        CONSTRAINT Address UNIQUE (State, City, StreetNumber, Zip, Street)
};


CREATE TABLE User {
        EmailAddress varchar(255) not null,
        Username varchar(255) not null,
        Password varchar(255),
        primary key(EmailAddress, Username)
};


CREATE TABLE Manager {
        Username varchar(255) foreign key references User(Username)
};


CREATE TABLE Customer {
        Username varchar(255) foreign key references User(Username)
};

CREATE TABLE PreferredTheater {
        foreign key TheaterID references Theater(TheaterID),
        foreign key Username references Customer(Username),
        primary key (TheaterID, Username)
};


CREATE TABLE CreditCard {
        CardNumber char(16) primary key,
        Username varchar(255) foreign key references User(Username),
        CVV char(3) not null,
        Holder varchar(255) not null,
        ExpirationDate varchar(255) not null,
};


CREATE TABLE Movie {
        Name varchar(255) primary key,
        AgeRating varchar(255),
        ReleaseDate varchar(255),
        Synopsis varchar(255),
        Price double,
        Duration time,
        Genre varchar(255)
};


CREATE TABLE Showing {
        ShowingID int primary key,
        Name varchar(255) foreign key references Movie(Name),
        TheaterID int foreign key references Theater(TheaterID),
Time timestamp
};


Create Table Review {
        Name varchar(255) foreign key references Movie(Name),
        Username varchar(255) foreign key references User(Username),
        ReviewID int  primary key,
Title varchar(255),
Comment varchar(2047),
Rating int
};


CREATE TABLE Cast {
MovieName varchar(255) foreign key references Movie(Name),
CastID int primary key,
Actor varchar(255),
Character varchar(255)
};




CREATE TABLE Order {
        OrderID int primary key,
Username varchar(255) foreign key references User(Username),
        CardNumber char(16) foreign key references
        CreditCard(CardNumber),
ChildTickets int,
AdultTickets int,
SeniorTickets int,
Status varchar(255)
};


CREATE TABLE SystemInfo {
        SystemInfoID int primary key,
        ManagerPassword varchar(255),
        SeniorDiscount float,
        ChildDiscount float,
        RefundFee float,
};
