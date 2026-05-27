CREATE TABLE Usuarios (
    ID_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Clave VARCHAR(255) NOT NULL,
    IntentosFallidos INT DEFAULT 0,
    Bloqueado BIT DEFAULT 0 
);
