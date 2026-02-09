CREATE DATABASE HealthClinicDB;
GO
USE HealthClinicDB;
GO

-- =========================
-- SPECIALTIES
-- =========================
CREATE TABLE Specialties
(
    SpecialtyId INT IDENTITY PRIMARY KEY,
    SpecialtyName VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX)
);

INSERT INTO Specialties (SpecialtyName, Description) VALUES
('Cardiology', 'Diagnosis and treatment of heart conditions.'),
('Dermatology', 'Diagnosis and treatment of skin conditions.'),
('Pediatrics', 'Medical care for infants, children, and adolescents.'),
('Orthopedics', 'Treatment of musculoskeletal system injuries and diseases.'),
('Neurology', 'Diagnosis and treatment of nervous system disorders.');

-- =========================
-- PATIENTS
-- =========================
CREATE TABLE Patients
(
    PatientId INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    Phone VARCHAR(15) UNIQUE NOT NULL,
    Email VARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- =========================
-- DOCTORS
-- =========================
CREATE TABLE Doctors
(
    DoctorId INT IDENTITY PRIMARY KEY,
    Name VARCHAR(100),
    SpecialtyId INT,
    Fee DECIMAL(10,2),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (SpecialtyId) REFERENCES Specialties(SpecialtyId)
);

-- =========================
-- APPOINTMENTS
-- =========================
CREATE TABLE Appointments
(
    AppointmentId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    AppointmentDate DATETIME,
    Status VARCHAR(20),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- =========================
-- VISITS
-- =========================
CREATE TABLE Visits
(
    VisitId INT IDENTITY PRIMARY KEY,
    AppointmentId INT,
    Diagnosis VARCHAR(200),
    Notes VARCHAR(500),
    VisitDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

-- =========================
-- PRESCRIPTIONS
-- =========================
CREATE TABLE Prescriptions
(
    PrescriptionId INT IDENTITY PRIMARY KEY,
    VisitId INT,
    Medicine VARCHAR(100),
    Dosage VARCHAR(50),
    Duration VARCHAR(50),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

-- =========================
-- BILLS
-- =========================
CREATE TABLE Bills
(
    BillId INT IDENTITY PRIMARY KEY,
    VisitId INT,
    TotalAmount DECIMAL(12,2),
    PaymentStatus VARCHAR(20) DEFAULT 'UNPAID',
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

-- =========================
-- PAYMENTS
-- =========================
CREATE TABLE Payments
(
    PaymentId INT IDENTITY PRIMARY KEY,
    BillId INT,
    Amount DECIMAL(12,2),
    Mode VARCHAR(20),
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BillId) REFERENCES Bills(BillId)
);
