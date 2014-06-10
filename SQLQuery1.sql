use master
go
create database Busetas
go
use Busetas
go
create table Bus(
id int identity,
brand varchar(100),
color varchar(100),
capacity int,
CONSTRAINT pk_BusId primary key (Id)
)
go
create table RouteSchedule(
id int identity, 
dayOfTheWeek varchar(100),
StartTime Time,
EndTime Time,
constraint pk_RouteScheduleId primary key(id)
)
go


create table EmployeeType(
id int identity, 
name varchar(100), 
description text,
constraint pk_EmployeeTypeId primary key (id)
)
go
create table Employee(
id int identity, 
name varchar(100), 
lastname varchar(100), 
email varchar(50), 
telephone varchar(50), 
employeeTypeId int,
constraint pk_EmployeeId primary key (id),
constraint fk_Employee_EmployeeTypeId foreign key (employeeTypeId) references EmployeeType(id)
)
go
create table Route(
id int identity, 
busId int, 
routeScheduleId int, 
goingToSchool bit, 
goingToHome bit, 
pilotId int, 
copilotId int,
constraint pk_RouteId primary key (id),
constraint fk_Route_BusId foreign key (busId) references Bus(id),
constraint fk_Route_RouteScheduleId foreign key (routeScheduleId) references RouteSchedule(id)
)

go
create table School(
id int identity,
name varchar (100), 
address varchar (250)
constraint pk_SchoolId primary key (id)
)
go
create table PersonInCharge(
id int identity, 
name varchar(100),
lastName varchar(100), 
email varchar(50), 
telephone varchar(50), 
address varchar(250),
constraint pk_PersonInChargeId primary key(id)
)
go
create table Student(
id int identity, 
name varchar(100),
lastName varchar(100),
age int, 
address varchar(250), 
telephone varchar(50),
personInChargeId int, 
schoolId int, 
constraint pk_StudentId primary key (id),
constraint fk_Student_PersonInChargeId foreign key (personInChargeId) references PersonInCharge(id),
constraint fk_Student_SchoolId foreign key (schoolId) references School(id)
 )
 go
 create table RouteStudent(
 id int identity, 
 routeId int, 
 studentId int,
 orderInRoute int,
constraint pk_RouteStudentId primary key (id),
constraint fk_RouteStudent_RouteId foreign key (routeId) references Route(id),
constraint fk_RouteStudent_StudentId foreign key (studentId) references Student(id)
)

go


alter table Route
add constraint fk_Route_PilotId foreign key (pilotId) references Employee(id)

alter table Route
add constraint fk_Route_CopilotId foreign key (copilotId) references Employee(id)

alter table EmployeeType
add salary decimal