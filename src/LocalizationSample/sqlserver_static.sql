SET IDENTITY_INSERT Cultures ON 
INSERT INTO Cultures (Id, Name) VALUES (1, 'vi-VN');
INSERT INTO Cultures (Id, Name) VALUES (2, 'fr-FR');
INSERT INTO Cultures (Id, Name) VALUES (3, 'pt-BR');
INSERT INTO Cultures (Id, Name) VALUES (4, 'es-ES');
INSERT INTO Cultures (Id, Name) VALUES (5, 'jp-JP');
INSERT INTO Cultures (Id, Name) VALUES (6, 'zh');
INSERT INTO Cultures (Id, Name) VALUES (7, 'zh-CN');
SET IDENTITY_INSERT Cultures OFF

INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (1, 'Hello {0}!', 'Chào {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (2, 'Hello {0}!', 'Bonjour {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (3, 'Hello {0}!', 'Olá {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (4, 'Hello {0}!', 'Hola {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (5, 'Hello {0}!', '????? {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (6, 'Hello {0}!', '?? {0}!');
INSERT INTO Resources (CultureId, [Key], [Value]) VALUES (7, 'Hello {0}!', '?? {0}!');