/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [UserID]
      ,[FullName]
      ,[ProfilImage]
      ,[Email]
      ,[Password]
      ,[Mobile]
  FROM [onlineTest].[dbo].[Users]

  CREATE TABLE `maincateogry` ( `MainCateogryID` INT NOT NULL AUTO_INCREMENT ,
   `MainCateogryName` VARCHAR(255) 
  NOT NULL , `CreatedDate` VARCHAR(200) NOT NULL , PRIMARY KEY (`MainCateogryID`))


  CREATE TABLE maincateogry (
    MainCateogryID INT PRIMARY KEY IDENTITY,
    MainCateogryName VARCHAR (255) NOT NULL,
    CreatedDate DATE NOT NULL
);


CREATE TABLE Subject (
        Subject_id INT IDENTITY PRIMARY KEY,
        SubjectName VARCHAR(100) NOT NULL,
        MainCateogryID INT NOT NULL,
        CONSTRAINT fk_group FOREIGN KEY (MainCateogryID) 
        REFERENCES maincateogry(MainCateogryID)
);


CREATE TABLE Topic (
        Topic_id INT IDENTITY PRIMARY KEY,
        TopicName VARCHAR(100) NOT NULL,
        MainCateogryID INT NOT NULL,
		 Subject_id INT NOT NULL,
        CONSTRAINT fk_maincat FOREIGN KEY (MainCateogryID) 
        REFERENCES maincateogry(MainCateogryID),
		CONSTRAINT fk_subject FOREIGN KEY (Subject_id) 
        REFERENCES Subject(Subject_id)
);


CREATE TABLE QuestionSet (
        Question_ID INT IDENTITY PRIMARY KEY,
        Question VARCHAR(100) NOT NULL,
		Option1 VARCHAR(100) NOT NULL,
		Option2 VARCHAR(100) NOT NULL,
		Option3 VARCHAR(100) NOT NULL,
		Option4 VARCHAR(100) NOT NULL,
		correctOption VARCHAR(100) NOT NULL,
        MainCateogryID INT NOT NULL,
		Subject_id INT NOT NULL,
		Topic_id INT NOT NULL,
		
        CONSTRAINT fk_maincateogry FOREIGN KEY (MainCateogryID) 
        REFERENCES maincateogry(MainCateogryID),
		CONSTRAINT fk_sub FOREIGN KEY (Subject_id) 
        REFERENCES Subject(Subject_id),
		CONSTRAINT fk_topic FOREIGN KEY (Topic_id) 
        REFERENCES Topic(Topic_id)
);
