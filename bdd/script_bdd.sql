-- ============================================================
-- Script SQL complet -- Base de données MediaTek86
-- Projet : MediaTekDocuments
-- Auteur  : Etudiant BTS SIO SLAM 1ère année
-- Date    : 2024
-- ============================================================

DROP DATABASE IF EXISTS mediatek86;
CREATE DATABASE mediatek86
    CHARACTER SET utf8
    COLLATE utf8_general_ci;

USE mediatek86;

-- ── Tables ────────────────────────────────────────────────────

CREATE TABLE service (
    id  INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE motif (
    id      INT AUTO_INCREMENT PRIMARY KEY,
    libelle VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE responsable (
    login VARCHAR(64) NOT NULL,
    pwd   VARCHAR(64) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE personnel (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    nom       VARCHAR(100) NOT NULL,
    prenom    VARCHAR(100) NOT NULL,
    tel       VARCHAR(20),
    mail      VARCHAR(150),
    idService INT NOT NULL,
    CONSTRAINT fk_personnel_service FOREIGN KEY (idService) REFERENCES service(id)
) ENGINE=InnoDB;

CREATE TABLE absence (
    id          INT AUTO_INCREMENT PRIMARY KEY,
    idPersonnel INT NOT NULL,
    dateDebut   DATE NOT NULL,
    dateFin     DATE NOT NULL,
    idMotif     INT NOT NULL,
    CONSTRAINT fk_absence_personnel FOREIGN KEY (idPersonnel) REFERENCES personnel(id),
    CONSTRAINT fk_absence_motif     FOREIGN KEY (idMotif)     REFERENCES motif(id)
) ENGINE=InnoDB;

-- ── Utilisateur MySQL ─────────────────────────────────────────
CREATE USER IF NOT EXISTS 'userMediatek'@'localhost' IDENTIFIED BY 'mdpMediatek86!';
GRANT ALL PRIVILEGES ON mediatek86.* TO 'userMediatek'@'localhost';
FLUSH PRIVILEGES;

-- ── Données statiques ─────────────────────────────────────────

INSERT INTO service (nom) VALUES
    ('Administratif'),
    ('Médiation culturelle'),
    ('Prêt');

INSERT INTO motif (libelle) VALUES
    ('Congé parental'),
    ('Maladie'),
    ('Motif familial'),
    ('Vacances');

-- Responsable : login=admin, pwd=admin123 hashé SHA256
INSERT INTO responsable (login, pwd) VALUES
    ('admin', SHA2('admin123', 256));

-- ── Personnel (10 exemples) ───────────────────────────────────
INSERT INTO personnel (nom, prenom, tel, mail, idService) VALUES
    ('Martin',   'Sophie',   '0612345678', 'sophie.martin@mediatek86.fr',   1),
    ('Dupont',   'Lucas',    '0623456789', 'lucas.dupont@mediatek86.fr',    2),
    ('Bernard',  'Marie',    '0634567890', 'marie.bernard@mediatek86.fr',   3),
    ('Leroy',    'Thomas',   '0645678901', 'thomas.leroy@mediatek86.fr',    1),
    ('Moreau',   'Julie',    '0656789012', 'julie.moreau@mediatek86.fr',    2),
    ('Simon',    'Nicolas',  '0667890123', 'nicolas.simon@mediatek86.fr',   3),
    ('Laurent',  'Camille',  '0678901234', 'camille.laurent@mediatek86.fr', 1),
    ('Lefebvre', 'Antoine',  '0689012345', 'antoine.lefebvre@mediatek86.fr',2),
    ('Michel',   'Isabelle', '0690123456', 'isabelle.michel@mediatek86.fr', 3),
    ('Garcia',   'Pierre',   '0601234567', 'pierre.garcia@mediatek86.fr',   1);

-- ── Absences (50 exemples) ────────────────────────────────────
INSERT INTO absence (idPersonnel, dateDebut, dateFin, idMotif) VALUES
    (1, '2024-01-08','2024-01-12', 4),
    (1, '2024-03-18','2024-03-22', 2),
    (2, '2024-01-15','2024-01-19', 4),
    (2, '2024-04-02','2024-04-05', 3),
    (3, '2024-02-05','2024-02-09', 2),
    (3, '2024-06-10','2024-06-21', 4),
    (4, '2024-01-22','2024-01-26', 1),
    (4, '2024-05-06','2024-05-10', 4),
    (5, '2024-02-12','2024-02-16', 2),
    (5, '2024-07-15','2024-07-26', 4),
    (6, '2024-03-04','2024-03-08', 3),
    (6, '2024-08-05','2024-08-16', 4),
    (7, '2024-01-29','2024-02-02', 2),
    (7, '2024-04-22','2024-04-26', 4),
    (8, '2024-02-19','2024-02-23', 1),
    (8, '2024-09-02','2024-09-13', 4),
    (9, '2024-03-11','2024-03-15', 2),
    (9, '2024-05-27','2024-05-31', 3),
    (10,'2024-01-08','2024-01-09', 2),
    (10,'2024-06-03','2024-06-14', 4),
    (1, '2024-07-01','2024-07-12', 4),
    (2, '2024-07-08','2024-07-19', 4),
    (3, '2024-09-16','2024-09-20', 2),
    (4, '2024-10-07','2024-10-11', 3),
    (5, '2024-10-14','2024-10-18', 2),
    (6, '2024-11-04','2024-11-08', 1),
    (7, '2024-11-18','2024-11-22', 2),
    (8, '2024-10-21','2024-10-25', 3),
    (9, '2024-12-02','2024-12-06', 4),
    (10,'2024-12-09','2024-12-13', 2),
    (1, '2024-08-26','2024-08-30', 3),
    (2, '2024-09-09','2024-09-13', 2),
    (3, '2024-10-28','2024-11-01', 4),
    (4, '2024-11-25','2024-11-29', 2),
    (5, '2024-12-16','2024-12-20', 3),
    (6, '2024-01-02','2024-01-05', 2),
    (7, '2024-02-26','2024-03-01', 3),
    (8, '2024-03-25','2024-03-29', 4),
    (9, '2024-04-15','2024-04-19', 1),
    (10,'2024-05-13','2024-05-17', 2),
    (1, '2024-05-20','2024-05-24', 3),
    (2, '2024-06-17','2024-06-21', 2),
    (3, '2024-07-22','2024-07-26', 4),
    (4, '2024-08-12','2024-08-16', 3),
    (5, '2024-08-19','2024-08-23', 2),
    (6, '2024-09-23','2024-09-27', 4),
    (7, '2024-10-14','2024-10-18', 3),
    (8, '2024-11-11','2024-11-15', 2),
    (9, '2024-12-23','2024-12-27', 4),
    (10,'2024-07-29','2024-08-02', 1);
