SELECT Persons.ID, Persons.Name as Owner_Name, MAX(Score) as Score, Pets.Name as Pet_Name
FROM Persons INNER JOIN Pets 
ON Persons.ID = Pets.owner_id
WHERE Persons.Score = (	SELECT MAX(Score) 
						FROM Persons INNER JOIN Pets 
						ON Persons.ID = Pets.owner_id) 
GROUP BY Persons.Name, Persons.Score, Persons.ID, Pets.Name

SELECT Persons.ID, Persons.Name, MAX(Score), Pets.Name
                   FROM Persons INNER JOIN Pets
                   ON Persons.ID = Pets.owner_id
                   WHERE Persons.Score = (SELECT MAX(Score)
                                           FROM Persons INNER JOIN Pets
                                           ON Persons.ID = Pets.owner_id)
                   GROUP BY Persons.Name, Persons.Score, Persons.ID, Pets.Name;