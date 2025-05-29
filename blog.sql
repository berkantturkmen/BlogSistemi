CREATE DATABASE blog_sistemi CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE blog_sistemi;

CREATE TABLE Kullanicilar (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    KullaniciAdi VARCHAR(50) UNIQUE,
    Sifre VARCHAR(100)
);

CREATE TABLE Kategoriler (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Ad VARCHAR(100)
);

CREATE TABLE Gonderiler (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Baslik VARCHAR(200),
    Icerik TEXT,
    ResimYolu VARCHAR(255),
    Tarih DATETIME,
    KategoriId INT,
    FOREIGN KEY (KategoriId) REFERENCES Kategoriler(Id)
);
