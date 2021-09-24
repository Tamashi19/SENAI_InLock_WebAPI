USE inLockGames;
GO


INSERT INTO tipoUsuario(titulo)
VALUES					('Administrador')
					   ,('Cliente');
GO

INSERT INTO usuario(email, senha, idTipoUsuario)
VALUES				('admin@gmail.com','123adm',1)
				   ,('cliente@cliente.com','321clt',2);
GO


INSERT INTO estudio(nomeEstudio)
VALUES				('Activision')
				   ,('Raven Software')
				   ,('Respawn Entertainment');
GO


INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Apex Legends','é um jogo eletrônico free-to-play do gênero battle royale','2019-01-04','00.00',1)
				,('Call of Duty: Vanguard','Call of Duty: Vanguard é um videogame de tiro em primeira pessoa','2021-11-05','150.00',2);
GO