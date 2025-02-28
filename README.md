# GymApp

-Inicio del proyecto del gimnasio. Adaptabilidades e ideas que complementaran la aplicación a medida que la vamos desarrollando.

CREATE TABLE Tipo_Usuarios (
  TipoUsuarioID INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255)
);

CREATE TABLE Usuarios (
  UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(100) NOT NULL,
  TipoUsuarioID INT NOT NULL,
  Email NVARCHAR(150),
  Contrasena NVARCHAR(255),
  Activo BIT DEFAULT 1,
  FOREIGN KEY (TipoUsuarioID) REFERENCES Tipo_Usuarios(TipoUsuarioID)
);

CREATE TABLE Clientes (
  ClienteID INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(100) NOT NULL,
  Apellido NVARCHAR(100) NOT NULL,
  Email NVARCHAR(150),
  Telefono NVARCHAR(20),
  FechaRegistro DATE DEFAULT GETDATE(),
  Activo BIT DEFAULT 1
);

CREATE TABLE Planes (
  PlanID INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(100) NOT NULL,
  Descripcion NVARCHAR(255),
  FechaCreacion DATE DEFAULT GETDATE()
);

CREATE TABLE Detalle_Planes (
  DetalleID INT IDENTITY(1,1) PRIMARY KEY,
  PlanID INT NOT NULL,
  Ejercicio NVARCHAR(100) NOT NULL,
  Repeticiones INT,
  Series INT,
  Descanso NVARCHAR(50),
  FOREIGN KEY (PlanID) REFERENCES Planes(PlanID)
);

CREATE TABLE Cliente_Plan (
  ClienteID INT NOT NULL,
  PlanID INT NOT NULL,
  FechaAsignacion DATE DEFAULT GETDATE(),
  PRIMARY KEY (ClienteID, PlanID),
  FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
  FOREIGN KEY (PlanID) REFERENCES Planes(PlanID)
);

CREATE TABLE Turnos (
  TurnoID INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  HoraInicio TIME NOT NULL,
  HoraFin TIME NOT NULL
);

CREATE TABLE Asistencias_General (
  AsistenciaID INT IDENTITY(1,1) PRIMARY KEY,
  UsuarioID INT,
  ClienteID INT,
  Fecha DATE DEFAULT GETDATE(),
  HoraIngreso TIME DEFAULT CONVERT(TIME, GETDATE()),
  HoraSalida TIME,
  FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
  FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

CREATE TABLE Movimientos (
  MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
  UsuarioID INT NULL,
  ClienteID INT NULL,
  TurnoID INT NULL,
  AsistenciaID INT NULL,
  FechaMovimiento DATE DEFAULT GETDATE(),
  Observaciones NVARCHAR(255),
  FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
  FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
  FOREIGN KEY (TurnoID) REFERENCES Turnos(TurnoID),
  FOREIGN KEY (AsistenciaID) REFERENCES Asistencias_General(AsistenciaID)
);
