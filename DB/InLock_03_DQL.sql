USE inLockGames;
GO


SELECT U.idUsuario, U.email, U.idTipoUsuario, TU.titulo FROM usuario U
INNER JOIN tipoUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario;
GO


SELECT idEstudio, nomeEstudio FROM estudio; 


SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogo;


SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio;
GO


SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM estudio E
LEFT JOIN jogo J
ON E.idEstudio = J.idEstudio;
GO


SELECT idUsuario, email, U.idTipoUsuario, TU.titulo FROM usuario U
INNER JOIN tipoUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'admin@gmail.com' AND senha = '123adm';
GO


SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio
WHERE J.idJogo = 1;
GO


SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM estudio E
INNER JOIN jogo J
ON E.idEstudio = J.idEstudio
WHERE E.idEstudio = 1;
GO


SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio
WHERE E.idEstudio = 1;
GO