--insert into AspNetRoles(Id) values ('Admin'), ('Teacher'), ('Student')
USE  Diary
insert into dbo.AspNetUserRoles values ('786cc51a-60f9-415d-b4ab-05cb4368404b', 'Admin')
select AspNetUsers.Id, FirstName, MiddleName, LastName, AspNetRoles.Name, Email, PasswordHash from AspNetUserRoles, AspNetUsers, AspNetRoles where AspNetUsers.id=AspNetUserRoles.UserId AND AspNetUserRoles.RoleId = AspNetRoles.Id
select * from  Teachers
select * from AspNetRoles
select * from  Subjects 
select * from  SubjectTeacher, Subjects, Teachers where SubjectTeacher.SubjectsId=Subjects.Id AND SubjectTeacher.TeachersId=Teachers.Id


select * from Classes
select * from AspNetRoles
select * from AspNetUserRoles
select * from AspNetUserRoles
select * from  Lessons
DELETE FROM AspNetUsers where UserName='4@yandex.ru'
DELETE FROM Students where id='4'
UPDATE  AspNetUsers set LastName='Волкова'	where id='f672c194-fee0-4080-9733-61a58ccd30ca'
