IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 1)
	UPDATE [Categories] 
		SET Categories.Name = 'Saludable'
			WHERE [Categories].Id = 1
ELSE
	INSERT INTO [Categories] (1, 'Saludable')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 2)
	UPDATE [Categories] 
		SET Categories.Name = 'Casero'
			WHERE [Categories].Id = 2
ELSE
	INSERT INTO [Categories] (2, 'Casero')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 3)
	UPDATE [Categories] 
		SET Categories.Name = 'Sushi'
			WHERE [Categories].Id = 3
ELSE
	INSERT INTO [Categories] (3, 'Sushi')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 4)
	UPDATE [Categories] 
		SET Categories.Name = 'Pescado'
			WHERE [Categories].Id = 4
ELSE
	INSERT INTO [Categories] (4, 'Pescado')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 5)
	UPDATE [Categories] 
		SET Categories.Name = 'Vegana'
			WHERE [Categories].Id = 5
ELSE
	INSERT INTO [Categories] (5, 'Vegana')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 6)
	UPDATE [Categories] 
		SET Categories.Name = 'ComidaRapida'
			WHERE [Categories].Id = 6
ELSE
	INSERT INTO [Categories] (6, 'ComidaRapida')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 7)
	UPDATE [Categories] 
		SET Categories.Name = 'Vegetariana'
			WHERE [Categories].Id = 7
ELSE
	INSERT INTO [Categories] (7, 'Vegetariana')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 8)
	UPDATE [Categories] 
		SET Categories.Name = 'Carne'
			WHERE [Categories].Id = 8
ELSE
	INSERT INTO [Categories] (8, 'Carne')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 9)
	UPDATE [Categories] 
		SET Categories.Name = 'Mexicana'
			WHERE [Categories].Id = 9
ELSE
	INSERT INTO [Categories] (9, 'Mexicana')

IF EXISTS (SELECT * FROM Categories WHERE [Categories].Id = 10)
	UPDATE [Categories] 
		SET Categories.Name = 'Fritos'
			WHERE [Categories].Id = 10
ELSE
	INSERT INTO [Categories] (10, 'Fritos')