use Sem3
go
INSERT INTO Category VALUES ('Digestive medicine', 'Medical');
INSERT INTO Category VALUES ('Headache and pain reliever', 'Medical');
INSERT INTO Category VALUES ('Fever and flu medicine', 'Medical');
INSERT INTO Category VALUES ('Microscope', 'Science');
INSERT INTO Category VALUES ('Blood pressure monitors', 'Science');
INSERT INTO Category VALUES ('Cardiac event monitor', 'Science');
INSERT INTO Category VALUES ('Pulse oximeter', 'Science');
INSERT INTO Category VALUES ('Medical Exam tables', 'Science');
go
select * from Category
go
INSERT INTO Product VALUES ('Culturelle', 1000, 'Brand	Culturelle
Flavor	Unflavored
Primary Supplement Type	Probiotic
Unit Count	30 Count
Item Form	Capsule
Item Weight	4.54 Grams
Item Dimensions LxWxH	1.25 x 3.66 x 5.5 inches
Special Ingredients	All Natural
Diet Type	Gluten Free
Product Benefits	Digestive Health Support, Immune Support', 'Culturelle.jpg', 'In stock', 1);
INSERT INTO Product VALUES ('Gas-X Relief Tablets', 1000, 'Brand	Gas-X
Special Feature	fast_acting
Item Weight	22.68 Grams
Item Dimensions LxWxH	1.22 x 2.75 x 4.53 inches
Product Benefits	Provides bloating and gas relief', 'Gas-XReliefTablets.jpg', 'In stock', 1);
INSERT INTO Product VALUES ('Advil Liqui-Gels', 2000, 'Brand	Advil
Special Feature	The medicine in Advil Liqui-Gels (Ibuprofen) is already dissolved in a soft gelatin capsule and works quickly to relieve pain at the site of inflammation.The medicine in Advil Liqui-Gels (Ibuprofen) is already dissolved in a soft gelatin capsule and works quickly to relieve pain at the site of inflammation.
Item Weight	4.64 Ounces
Item Dimensions LxWxH	6 x 5 x 4 inches
Product Benefits	Headache, Menstrual Pain, Joint Pain Relief, Backache, Fever', 'AdvilLiqui-Gels.jpg', 'In stock', 2);
INSERT INTO Product VALUES ('Motrin IB', 2000, 'Brand	Motrin
Special Feature	Temporarily relieves minor aches and pains
Item Weight	0.18 Grams
Item Dimensions LxWxH	6 x 5 x 4 inches
Product Benefits	Back Pain Relief', 'MotrinIB.jpg', 'In stock', 2);
INSERT INTO Product VALUES ('Daytime Cold and Flu', 30000, 'Brand	Amazon Basic Care
Special Feature	Non Drowsy
Item Dimensions LxWxH	1 x 4.38 x 3.25 inches
Product Benefits	Cold and Flu Control
Specific Uses For Product	Cold', 'DaytimeColdandFlu.jpg', 'In stock', 3);
INSERT INTO Product VALUES ('Boiron Oscillococcinum', 3000, 'Brand	Boiron
Special Feature	Non Drowsy, Fast Acting
Item Weight	0.04 Ounces
Item Dimensions LxWxH	2 x 2 x 2 inches
Product Benefits	Cold and Flu Control', 'BoironOscillococcinum.jpg', 'In stock', 3);
INSERT INTO Product VALUES ('AmScope 120X-1200X 52-pcs', 4000, 'Light Source Type	LED
Model Name	M30 ABS KT2 W
Material	ABS, Plastic, Metal
Color	White
Product Dimensions	14.57 L x 5.12 W x 15.75H
Real Angle of View	90 Degrees
Magnification Maximum	1200 x
Item Weight	3.7 Pounds
Brand	AmScope
Objective Lens Description	Achromatic', 'AmScope120X-1200X.jpg', 'In stock', 4);
INSERT INTO Product VALUES ('AmScope M150C-I 40X-1000X', 4000, 'Light Source Type	LED
Model Name	M150C-I 40X-1000X
Material	Glass
Color	Silver, White, Black
Product Dimensions	10L x 7W x 15H
Real Angle of View	90 Degrees
Magnification Maximum	1000 x
Voltage	110 Volts
Brand	AmScope
Objective Lens Description	Achromatic', 'AmScope_M150C-I.jpg', 'In stock', 4);
INSERT INTO Product VALUES ('Beurer BM27 Upper Arm Blood Pressure Monitor', 5000, 'Brand	Beurer
Included Components	Cuff
Power Source	Battery Powered
Use for	Arm
Display Type	LCD
Size	Large
Age Range (Description)	Adult
Item Weight	12 Ounces
Model Name	BM27
Band Size	16.5 inch', 'Beurer_BM27.jpg', 'In stock', 5);
INSERT INTO Product VALUES ('Portable-Small Blood-Pressure Monitors', 5000, 'Brand	angel wish
Included Components	Home Blood Pressure Monitor x 1; Adjustable Arm Cuff x 1, Users Manual x 1
Power Source	Battery Powered/Charging Powered
Use for	Arm
Display Type	LCD
Size	Regular
Age Range (Description)	Adult
Model Name	Blood Pressure Monitor
Band Size	12.6 inch
Material Feature	Durable', 'Portable-Small.jpg', 'In stock', 5);
INSERT INTO Product VALUES ('Garmin 010-13118-00 HRM-Pro Plus', 6000, 'Brand	Garmin
Material	Nylon
Color	Black
Compatible Devices	Smartphones
Screen Size	0.96 Inches
Product Dimensions	1.18L x 0.47W x 23.62H
Item Weight	51 Grams
Battery Life	8760 Hours
Sensor Type	Wearable
Battery Description	Lithium-Ion', 'Garmin.jpg', 'In stock', 6);
INSERT INTO Product VALUES ('POLAR Unite Waterproof Fitness Watch & H9 Heart Rate Monitor Bundle', 6000, 'Brand	POLAR
Model Name	Unite
Color	White
Screen Size	1.2 Inches
Special Feature	Bluetooth
Age Range (Description)	Kid
Display Type	LED
Band Color	White
Battery Life	4 days
Connectivity Technology	Bluetooth', 'POLAR_Unite.jpg', 'In stock', 6);
INSERT INTO Product VALUES ('Zacurate 500C Elite', 7000, '
Brand	Zacurate
Color	Mystic Black
Number of Batteries	2 AAA batteries required. (included)
Battery Life	30 Hours
Are Batteries Included	Yes', 'Zacurate500CElite.jpg', 'In stock', 7);
INSERT INTO Product VALUES ('HealthSmart ', 7000, 'Brand	HealthSmart
Color	Red OLED
Measuring Range	70%~99% ± 2 digits
Number of Batteries	2 AAA batteries required. (included)
Model Name	HealthSmart Pulse Ox', 'HealthSmart.jpg', 'In stock', 7);
INSERT INTO Product VALUES ('Armedica AM-300 HI-LO', 8000, 'Brand	Armedica
Shape	Rectangular
Product Care Instructions	Wipe with Dry Cloth
Material	Steel,Welded', 'Armedica_AM-300_HI-LO.jpg', 'In stock', 8);
INSERT INTO Product VALUES ('MedSurface Med Surface', 8000, '
Brand	MedSurface
Shape	Rectangular
Product Care Instructions	Wipe with Dry Cloth', 'MedSurface_Med_Surface.jpg', 'In stock', 8);
go
select * from Product
go
INSERT INTO News VALUES ('Conference on treatment work in the field of Traditional Medicine and Pharmacy', 'On December 11, 2023 in Nghe An, the Ministry of Health organized a conference to discuss medical examination and treatment in the field of Traditional Medicine and Pharmacy with the theme Combining traditional medicine with modern medicine. Deputy Minister of Health Do Xuan Tuyen chaired the conference.', 'Speaking at the conference, Deputy Minister of Health Do Xuan Tuyen said that in recent years, with the attention of the Party and State, traditional medicine has inherited, promoted, and developed, achieving important achievements. important in protecting and caring for peoples health. Directions to prioritize the development of traditional medicine (TCM), combining Traditional Medicine with modern medicine, are clearly shown in the content of the Constitution, Platform of the Party Congress, and Resolution of the Central Executive Committee. Central Committee, Politburo and directives of the Secretariat.
Combining traditional medicine with modern medicine is strictly implemented in all fields, from the system of legal documents such as the Law on Medical Examination and Treatment, the Law on Pharmacy,... the state management system of health to medical examination and treatment system, training programs, scientific research, professional documents guiding the implementation of medical examination and treatment, investing in infrastructure construction, purchasing medical equipment, updating Continuous medical knowledge, improving professional qualifications for medical examination and treatment practitioners.', GETDATE(), 'yte1.jpg','Medical');
INSERT INTO News VALUES ('Propose amendments and supplements to regulations on registration and circulation of drugs and medicinal ingredients', 'In the draft Law amending and supplementing a number of articles of the Pharmacy Law, the Ministry of Health proposes to amend and supplement regulations on registration and circulation of drugs and medicinal ingredients.','Specifically, the Ministry of Health proposes to amend Point a, Clause 2, Article 54 of the Pharmacy Law, accordingly, medicinal ingredients used to produce drugs according to drug registration dossiers that already have a certificate of registration for circulation in Vietnam do not have to be processed. registration for circulation to reduce and simplify administrative procedures.
The draft also proposes to supplement Clause 6, Article 56 of the Pharmacy Law, in which, no further extension of the validity of the circulation registration certificate for drugs and medicinal ingredients that have not been circulated on the market within the validity period has been granted. circulation registration certificate.', GETDATE(), 'yte2.jpg', 'Medical');
INSERT INTO News VALUES ('Bidding for medical equipment has been resolved', 'The Ministry of Health has just issued Circular 08/2023/TT-BYT abolishing a number of legal documents issued by the Minister of Health. Including Circular No. 14/2020/TT-BYT dated July 10, 2020 of the Minister of Health regulating a number of contents in bidding for medical equipment at public medical facilities.','Specifically, Circular 08/2023/TT-BYT abolishes all 3 legal documents issued by the Minister of Health, including:
Circular No. 03/2016/TT-BYT dated January 21, 2016 of the Minister of Health regulating pharmaceutical business activities.
Circular No. 31/2019/TT-BYT dated December 5, 2019 of the Minister of Health regulating requirements for fresh milk products used in the School Milk Program.
Circular No. 14/2020/TT-BYT dated July 10, 2020 of the Minister of Health regulating a number of contents in bidding for medical equipment at public medical facilities.', GETDATE(), 'kh3.jpg', 'Science');
go
select * from News
go
INSERT INTO Account VALUES ('Admin','admin@gmail.com', '123456', '0912345678', N'Tòa Nhà HTC-250 Hoàng Quốc Việt-Cổ Nhuế-Cầu Giấy-Hà Nội', 'acc1.jpg', 'In force', 'admin');
INSERT INTO Account VALUES ('User','user@gmail.com', '123456', '0987654321', N'Tòa Nhà HTC-250 Hoàng Quốc Việt-Cổ Nhuế-Cầu Giấy-Hà Nội', 'acc2.jpg', 'In force', 'user');
INSERT INTO Account VALUES ('User2','user2@gmail.com', '123456', '0987654321', N'Tòa Nhà HTC-250 Hoàng Quốc Việt-Cổ Nhuế-Cầu Giấy-Hà Nội', 'acc2.jpg', 'Disable', 'user');
go
select * from Account
go
INSERT INTO Comment VALUES ('hdgguighestaurifdfehwheijbjzmbvnnjguyrgggrhykiljhftyktstshttnmv,cxe',2,1);
INSERT INTO Comment VALUES ('tetdhrfyykilieqerwteyurtiyoufdstouhiusrurhjjrirxuirytyyruiertfweudfesayygdfyeafgheuyufuyuesyeuueugbhtygthghhghjgguughhuuvyhcjnnnai',2,2);
go
select * from Comment
go