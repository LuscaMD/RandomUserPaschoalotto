CREATE DATABASE "RandomUserGeneratorApi"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.utf8'
    LC_CTYPE = 'Portuguese_Brazil.utf8'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
	
CREATE TABLE "User"
(
	"IdUser" SERIAL PRIMARY KEY,
	"Gender" VARCHAR(200),
	"Name_Title" VARCHAR(200),
	"Name_First" VARCHAR(200),
	"Name_Last" VARCHAR(200),
	"Location_Street_number" int,
	"Location_Street_name" VARCHAR(200),
	"Location_City" VARCHAR(200),
	"Location_State" VARCHAR(200),
	"Location_Country" VARCHAR(200),
	"Location_Postcode" int,
	"Location_Coordinates_latitude" VARCHAR(200),
	"Location_Coordinates_longitude" VARCHAR(200),
	"Location_Timezone_offset" VARCHAR(200),
	"Location_Timezone_description" VARCHAR(200),
	"Email" VARCHAR(200),
	"Login_Uuid" VARCHAR(200),
	"Login_Username" VARCHAR(200),
	"Login_Password" VARCHAR(200),
	"Login_Salt" VARCHAR(200),
	"Login_Md5" VARCHAR(200),
	"Login_Sha1" VARCHAR(200),
	"Login_Sha256" VARCHAR(200),
	"Dob_Date" VARCHAR(200),
	"Dob_Age" int,
	"Registered_DateRegistered" VARCHAR(200),
	"Registered_AgeRegistered" int,
	"Phone" VARCHAR(200),
	"Cell" VARCHAR(200),
	"Id_NameId" VARCHAR(200),
	"Id_ValueId" VARCHAR(200),
	"Picture_Large" VARCHAR(200),
	"Picture_Medium" VARCHAR(200),
	"Picture_Thumbnail" VARCHAR(200),
	"Nat" VARCHAR(200) 
)