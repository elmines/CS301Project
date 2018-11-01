create table Theater (
        ID    	     varchar(255)  primary key,
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
        Password     varchar(255) not null
);


create table Manager (
        Username varchar(255) primary key references AccountUser(Username)
);


create table Customer (
        Username varchar(255) primary key references AccountUser(Username)
);

create table PreferredTheater (
        TheaterID varchar(255) references Theater(ID),
        Username  varchar(255) references Customer(Username),
        primary key (TheaterID, Username)
);


create table CreditCard (
        CardNumber     char(16)     not null,
        Username       varchar(255) references Customer(Username),
        CVV            char(3)      not null,
        Holder         varchar(255) not null,
        ExpirationDate varchar(255) not null,
        Saved          int not null,                       --0, everything else is true
        primary key (CardNumber, UserName)
);


create table Movie (
        Name        varchar(255)  primary key,
        AgeRating   varchar(255),
        ReleaseDate varchar(255),
        Synopsis    varchar(255),
        Price       float         not null check(Price >= 0),
        Duration    int           not null check(Duration > 0),
        Genre       varchar(255)
);


create table Showing (
        ID          varchar(255) primary key,
        MovieName   varchar(255) references Movie(Name),
        TheaterID 	varchar(255) references Theater(ID),
        StartTime  timestamp
);


create table Review (
        ID  	  varchar(255)   primary key,
        MovieName varchar(255)   references Movie(Name),
        Username  varchar(255)   references Customer(Username),
        Title     varchar(255),
        Body      varchar(2047),
        Rating    int            not null check(Rating >= 0 AND Rating <= 5)
);


create table Cast (
        ID    	  varchar(255)  primary key,
        MovieName varchar(255)  references Movie(Name),
        Actor     varchar(255),
        Character varchar(255)
);


create table TicketOrder (
        ID            varchar(255)  primary key,
        ShowingID     varchar(255)  references Showing(ID),
        Username      varchar(255),
        CardNumber    char(16),
        Cost          float         not null check(Cost >= 0),
        ChildTickets  int           not null check(ChildTickets >= 0),
        AdultTickets  int           not null check(AdultTickets >= 0),
        SeniorTickets int           not null check(SeniorTickets >= 0),
        Status        varchar(255),

        foreign key (CardNumber, Username) references CreditCard(CardNumber, UserName)
);


create table SystemInfo (
        ID              varchar(255)  primary key,
        ManagerPassword varchar(255)  not null,
        SeniorDiscount  float         not null check(0.0 <= SeniorDiscount and SeniorDiscount <= 1.0),
        ChildDiscount   float         not null check(0.0 <= ChildDiscount and ChildDiscount <= 1.0),
        RefundFee       float         not null check(RefundFee >= 0.0)
);
