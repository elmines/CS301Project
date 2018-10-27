create table Theater (
        TheaterID    int           primary key,
        Name         varchar(255),
        State        varchar(255),
        City         varchar(255),
        StreetNumber varchar(255),
        Street       varchar(255),
        Zip          char(5),
        constraint Address unique (State, City, StreetNumber, Zip, Street)
);


create table AccountUser (
        Username     varchar(255) primary key,
        EmailAddress varchar(255) not null unique,
        Password     varchar(255) not null unique
);


create table Manager (
        Username varchar(255) primary key references AccountUser(Username)
);


create table Customer (
        Username varchar(255) primary key references AccountUser(Username)
);

create table PreferredTheater (
        TheaterID int            references Theater(TheaterID),
        Username  varchar(255)   references Customer(Username),
        primary key (TheaterID, Username)
);


create table CreditCard (
        CardNumber     char(16)     not null,
        Username       varchar(255) references Customer(Username),
        CVV            char(3)      not null,
        Holder         varchar(255) not null,
        ExpirationDate varchar(255) not null,
        Saved          int,
        primary key (CardNumber, UserName)
);


create table Movie (
        Name        varchar(255) primary key,
        AgeRating   varchar(255),
        ReleaseDate varchar(255),
        Synopsis    varchar(255),
        Price       float        not null,
        Duration    int,
        Genre       varchar(255)
);


create table Showing (
        ShowingID int          primary key,
        Name      varchar(255) references Movie(Name),
        TheaterID int          references Theater(TheaterID),
        StartTime timestamp
);


create table Review (
        ReviewID  int            primary key,
        MovieName varchar(255)   references Movie(Name),
        Username  varchar(255)   references Customer(Username),
        Title     varchar(255),
        Body      varchar(2047),
        Rating    int            not null
);


create table Cast (
        CastID    int           primary key,
        MovieName varchar(255)  references Movie(Name),
        Actor     varchar(255),
        Character varchar(255)
);


create table TicketOrder (
        OrderID       int           primary key,
        ShowingID     int           references Showing(ShowingID),
        Username      varchar(255),
        CardNumber    char(16),
        Cost          float         not null,
        ChildTickets  int,
        AdultTickets  int,
        SeniorTickets int,
        Status        varchar(255),

        foreign key (CardNumber, Username) references CreditCard(CardNumber, UserName)
);


create table SystemInfo (
        SystemInfoID    int           primary key,
        ManagerPassword varchar(255)  not null,
        SeniorDiscount  float         not null,
        ChildDiscount   float         not null,
        RefundFee       float         not null
);
