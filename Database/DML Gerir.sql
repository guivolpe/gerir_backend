INSERT INTO Usuarios(Id, Nome, Email, Senha, Tipo)
VALUES(NEWID(), 'Fernando Henrique', 'fhguerra@outlook.com', '123456', 'Comon')

SELECT * FROM Usuarios

INSERT INTO Usuarios
VALUES(NEWID(), 'Priscila Medeiros', 'primedeiro@gmail.com', '123456', 'Comon')

--Altera Tabela
UPDATE Usuarios SET Tipo = 'Comum'

UPDATE Usuarios SET Nome = 'Fernando Henrique Guerra'
WHERE ID = 'D0FA721C-391C-40EB-8B16-8A274C29D9B0'

--DELETA LINHA
DELETE from Usuarios WHERE ID = 'EB73FC97-6826-4308-96C3-094D3CC2C131'




INSERT INTO Tarefas(Id, Titulo, Descricao, Categoria, DataEntrega, Status, Usuario_Id )
VALUES(NEWID(), 'Tarefa 1', 'Descricao da tarefa 1', 'Pessoal','04-01-2021 18:00:00', '0', 'D0FA721C-391C-40EB-8B16-8A274C29D9B0')

SELECT * FROM Tarefas

SELECT * FROM Usuarios

INSERT INTO Tarefas(Id, Titulo, Descricao, Categoria, DataEntrega, Status, Usuario_Id )
VALUES(NEWID(), 'Tarefa 2', 'Descricao da tarefa 2', 'Pessoal','04-01-2021 18:00:00', '0', '2E6823A6-2876-4195-89F6-6DE57E240387')

INSERT INTO Tarefas(Id, Titulo, Descricao, Categoria, DataEntrega, Status, Usuario_Id )
VALUES(NEWID(), 'Tarefa 2', 'Descricao da tarefa 2', 'Pessoal','04-01-2021 18:00:00', '0', 'D0FA721C-391C-40EB-8B16-8A274C29D9B0')

UPDATE Tarefas SET Titulo = 'Tarefa 1' ,Descricao = 'Descricao da tarefa 1'
WHERE ID = 'D10CAB08-ED34-406E-A81E-6077A4F3B58F'



SELECT * FROM Usuarios

--INNER JOIN

SELECT 
u.Id AS Id_Usuario, 
u.Nome, 
u.Email,
t.id as id_tarefa,
t.Titulo,
t.Descricao,
t.Categoria,
t.Status,
t.DataEntrega
FROM Usuarios u
INNER JOIN Tarefas t ON t.Usuario_Id = u.Id
WHERE u.Id = 'D0FA721C-391C-40EB-8B16-8A274C29D9B0'

UPDATE Tarefas SET Status = 1 
WHERE Id= '4A3D17F1-E78F-40A0-A93F-FCABB83CBD8E'





SELECT * FROM Tarefas