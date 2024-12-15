create table  student(
     id bigint identity(1,1) primary key,
     registrationNumber varchar(20),
     firstName varchar(50),
     lastName varchar(50),
     email varchar(50),
     phoneNumber varchar(20),
     department varchar(50),
);

alter table student
  add constraint student_registration_number_uindex unique (registrationNumber);

alter table student
    add constraint student_email_uindex unique (email);

alter table student
    add constraint student_phone_number_uindex unique (phoneNumber);
