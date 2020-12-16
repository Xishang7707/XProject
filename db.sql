/*
 Navicat Premium Data Transfer

 Source Server         : 本地
 Source Server Type    : PostgreSQL
 Source Server Version : 130000
 Source Host           : 192.168.56.101:5432
 Source Catalog        : XProj
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 130000
 File Encoding         : 65001

 Date: 17/12/2020 06:49:39
*/


-- ----------------------------
-- Table structure for sv_project
-- ----------------------------
DROP TABLE IF EXISTS "public"."sv_project";
CREATE TABLE "public"."sv_project" (
  "id" varchar(32) COLLATE "pg_catalog"."default" NOT NULL,
  "projectname" varchar(100) COLLATE "pg_catalog"."default",
  "addtime" timestamp(6)
)
;
COMMENT ON COLUMN "public"."sv_project"."projectname" IS '项目名称';
COMMENT ON COLUMN "public"."sv_project"."addtime" IS '添加时间';

-- ----------------------------
-- Table structure for sv_server
-- ----------------------------
DROP TABLE IF EXISTS "public"."sv_server";
CREATE TABLE "public"."sv_server" (
  "id" varchar(32) COLLATE "pg_catalog"."default" NOT NULL,
  "name" varchar(30) COLLATE "pg_catalog"."default",
  "host" varchar(255) COLLATE "pg_catalog"."default",
  "port" int4,
  "user" varchar(128) COLLATE "pg_catalog"."default",
  "password" varchar(255) COLLATE "pg_catalog"."default",
  "privatekey" varchar(4096) COLLATE "pg_catalog"."default",
  "logintype" int4
)
;
COMMENT ON COLUMN "public"."sv_server"."name" IS '服务器名称';
COMMENT ON COLUMN "public"."sv_server"."host" IS '主机地址';
COMMENT ON COLUMN "public"."sv_server"."port" IS '连接端口';
COMMENT ON COLUMN "public"."sv_server"."user" IS '连接用户名';
COMMENT ON COLUMN "public"."sv_server"."password" IS '连接密码';
COMMENT ON COLUMN "public"."sv_server"."privatekey" IS '私钥';
COMMENT ON COLUMN "public"."sv_server"."logintype" IS '连接方式(0=尝试 1=密码 2=私钥)';

-- ----------------------------
-- Primary Key structure for table sv_project
-- ----------------------------
ALTER TABLE "public"."sv_project" ADD CONSTRAINT "project_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sv_server
-- ----------------------------
ALTER TABLE "public"."sv_server" ADD CONSTRAINT "sv_server_pkey" PRIMARY KEY ("id");
