create database simpledb;
use simpledb;
create table users(userId int not null auto_increment primary key,contactNumber bigint not null unique,otp int not null);
insert into users (contactNumber,otp) values (9075966080,123432),(7448022740,456786);
