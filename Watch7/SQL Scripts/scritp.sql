/* ============================================================ */
/*   Database name:  WATCH7 Database                            */
/*   DBMS name:      Microsoft SQL Server 6.x                   */
/*   Created on:     20/05/2025  0:33                           */
/* ============================================================ */

/* ============================================================ */
/*   Table: ZONAS                                               */
/* ============================================================ */
create table ZONAS
(
    ID_ZONA             int  identity(1,1)    not null,
    NOMBRE_ZONA         varchar(100)          not null,
    constraint PK_ZONAS primary key (ID_ZONA)
)
go

/* ============================================================ */
/*   Table: TIPOS                                                */
/* ============================================================ */
create table TIPOS
(
    ID_TIPO             int  identity(1,1)    not null,
    MODELO_HARD         varchar(100)          not null,
    constraint PK_TIPOS primary key  (ID_TIPO)
)
go

/* ============================================================ */
/*   Table: INSTALACIONES                                       */
/* ============================================================ */
create table INSTALACIONES
(
    ID_INSTALACION      int  identity(1,1)    not null,
    ID_ZONA             int                   not null,
    NOMBRE_INSTALACION  varchar(100)          not null,
    constraint PK_INSTALACIONES primary key (ID_INSTALACION)
)
go

/* ============================================================ */
/*   Index: ZONA_INSTALACION_FK                                 */
/* ============================================================ */
create index ZONA_INSTALACION_FK on INSTALACIONES (ID_ZONA)
go

/* ============================================================ */
/*   Table: EQUIPOS                                             */
/* ============================================================ */
create table EQUIPOS
(
    ID_EQUIPO                  int  identity(1,1)    not null,
    ID_INSTALACION             int                   not null,
    NOMBRE_EQUIPO              varchar(100)          null    ,
    constraint PK_EQUIPOS primary key (ID_EQUIPO)
)
go

/* ============================================================ */
/*   Index: RELATION_104_FK                                     */
/* ============================================================ */
create index RELATION_104_FK on EQUIPOS (ID_INSTALACION)
go


/* ============================================================ */
/*   Table: CPUS                                                */
/* ============================================================ */
create table CPUS
(
    ID_CPU              int  identity(1,1)    not null,
    ID_EQUIPO           int                   not null,
    ID_TIPO             int                   not null,
    NOMBRE_CPU          varchar(100)          not null,
    IP_CPU              varchar(100)          not null,
    RACK_CPU            int                   not null,
    SLOT_CPU            int                   not null,
    DIRECCION_CPU       int                   not null,
    PERIODO_CPU         int                   not null,
    ESTADO_CPU          int                   not null,
    CHECKSUM_CPU        int                   not null,
    CHECKSUMDATE_CPU    datetime2             not null,
   
    constraint PK_CPUS primary key (ID_CPU)
)
go

/* ============================================================ */
/*   Index: EQUIPOS_CPU_FK                                      */
/* ============================================================ */
create index EQUIPOS_CPU_FK on CPUS (ID_EQUIPO)
go

/* ============================================================ */
/*   Index: CPU_TIPOS_FK                                        */
/* ============================================================ */
create index CPU_TIPOS_FK on CPUS (ID_TIPO)
go



/* ============================================================ */
/*   Table: LOGS                                                */
/* ============================================================ */
create table LOGS
(
    ID_LOG              int  identity(1,1)    not null,
    ID_CPU              int                   null    ,
    CLASE_LOG           int                   null    ,
    FECHA_LOG           datetime              not null,
    TEXT_LOG            varchar(1000)         not null,
    constraint PK_LOGS primary key (ID_LOG)
)
go

/* ============================================================ */
/*   Index: CPU_LOGS_FK                                         */
/* ============================================================ */
create index CPU_LOGS_FK on LOGS (ID_CPU)
go


/* ============================================================ */
/*   Table: LOGAPP                                              */
/* ============================================================ */
create table LOGAPP
(
    ID_LOGAPP              int  identity(1,1)    not null,
    FECHA_LOGAPP           datetime              not null,
    TEXT_LOGAPP            varchar(1000)         not null,
    constraint PK_LOGAPP primary key (ID_LOGAPP)
)
go




alter table INSTALACIONES
    add constraint FK_INSTALAC_ZONA_INST_ZONAS foreign key  (ID_ZONA)
       references ZONAS (ID_ZONA) ON DELETE CASCADE
go

alter table EQUIPOS
    add constraint FK_EQUIPOS_RELATION__INSTALAC foreign key  (ID_INSTALACION)
       references INSTALACIONES (ID_INSTALACION) ON DELETE CASCADE
go


alter table CPUS
    add constraint FK_CPUS_EQUIPOS_C_EQUIPOS foreign key  (ID_EQUIPO)
       references EQUIPOS (ID_EQUIPO) ON DELETE CASCADE
go

alter table CPUS
    add constraint FK_CPUS_CPU_TIPOS_TIPO foreign key  (ID_TIPO)
       references TIPOS (ID_TIPO)
go


alter table LOGS
    add constraint FK_LOGS_CPU_LOGS_CPUS foreign key  (ID_CPU)
       references CPUS (ID_CPU)  ON DELETE CASCADE
go


INSERT INTO TIPOS (MODELO_HARD) values 
('SIEMENS S7-300'),
('SIEMENS S7-400'),
('SIEMENS S7-1200'),
('SIEMENS S7-1500'),
('OMRON CPU'),
('ALLEN-BRADLEY ControlLogix'),
('ALLEN-BRADLEY CompactLogix'),
('ALLEN-BRADLEY GuardLogix'),
('ALLEN-BRADLEY SoftLogix');
go

