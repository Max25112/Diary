--insert into AspNetRoles(Id) values ('Admin'), ('Teacher'), ('Student')

insert into dbo.AspNetUserRoles values ('786cc51a-60f9-415d-b4ab-05cb4368404b', 'Admin')
select * from AspNetUserRoles, AspNetUsers where AspNetUsers.id=AspNetUserRoles.UserId
select * from  Subjects 
select * from  SubjectTeacher
select * from Classes
select * from AspNetUsers
select * from  Teachers
select * from  Students
DELETE FROM AspNetUsers where UserName='4@yandex.ru'
DELETE FROM Students where id='4'
insert into  Students value (id='0', );