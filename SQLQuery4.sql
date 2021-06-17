--insert into AspNetRoles(Id) values ('Admin'), ('Teacher'), ('Student')
USE  Diary
insert into dbo.AspNetUserRoles values ('786cc51a-60f9-415d-b4ab-05cb4368404b', 'Admin')
select AspNetUsers.Id, FirstName, MiddleName, LastName, AspNetRoles.Name, Email, PasswordHash from AspNetUserRoles, AspNetUsers, AspNetRoles where AspNetUsers.id=AspNetUserRoles.UserId AND AspNetUserRoles.RoleId = AspNetRoles.Id
select * from  Teachers
select * from AspNetRoles
select * from  SubjectTeacher
select * from  SubjectTeacher, Subjects, Teachers where SubjectTeacher.SubjectsId=Subjects.Id AND SubjectTeacher.TeachersId=Teachers.Id
select FirstName, MiddleName, LastName, Classes.Name from AspNetUsers, Students, Classes, Lessons where AspNetUsers.Id = Students.UserId 
AND Students.ClassId=Classes.Id AND Lessons.ClassId = Classes.Id
select * from  Students inner join AspNetUsers on Students.UserId=AspNetUsers.Id
select * from  Teachers inner join AspNetUsers on Teachers.UserId=AspNetUsers.Id

select * from Classes
select * from Homeworks
select * from HomeworkResults
select HomeworkResults.Id, Classes.Name, HomeworkResults.ClassId, HomeworkResults.TeacherId, Grade from HomeworkResults, Classes, Teachers where HomeworkResults.ClassId=Classes.Id And
Teachers.Id=HomeworkResults.TeacherId
select * from Attachments
select * from Lessons
select * from AspNetRoles
select * from AspNetUserRoles
select * from AspNetUserRoles
select * from  Lessons, Students, Classes 
select Classes.Name, Lessons.TeacherId, Lessons.Day from Lessons, Classes, Teachers where Lessons.ClassId = Classes.Id AND Lessons.TeacherId = Teachers.Id
DELETE FROM AspNetUsers where UserName='student2@yandex.ru'
DELETE FROM HomeworkResults where id='8'
UPDATE  AspNetUsers set LastName='Волкова'	where id='f672c194-fee0-4080-9733-61a58ccd30ca'
