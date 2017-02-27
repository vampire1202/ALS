using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:treatmentmode
    /// </summary>
    public partial class treatmentmode
    {
        public treatmentmode()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_treatmentmode");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.treatmentmode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_treatmentmode(");
            strSql.Append("name,BPSpeed,BPDirection,BPValid,FPSpeed,FPDirection,FPValid,DPSpeed,DPDirection,DPValid,RPSpeed,RPDirection,RPValid,FP2Speed,FP2Direction,FP2Valid,CPSpeed,CPDirection,CPValid,dehydrationSpeed,dehydrationValid,TargetTimeH,TargetTimeMin,IsTargetTime,TargetBP,IsTargetBP,TargetDP,IsTargetDP,TargetSP,IsTargetSP,TargetRP,IsTargetRP,TargetFP,IsTargetFP,Concentration,SP_Speed,SP_RapidInjectionValue,TargetT,PaccUpper,PaccLower,PartUpper,PartLower,PvenUpper,PvenLower,P1stUpper,P1stLower,P2ndUpper,P2ndLower,TmpUpper,TmpLower,PrePaccLower,PrePvenUpper,BloodLeak,P3rdLower,P3rdUpper,LeadBloodSpeed,LeadBloodTime,PaccDecrement)");
            strSql.Append(" values (");
            strSql.Append("@name,@BPSpeed,@BPDirection,@BPValid,@FPSpeed,@FPDirection,@FPValid,@DPSpeed,@DPDirection,@DPValid,@RPSpeed,@RPDirection,@RPValid,@FP2Speed,@FP2Direction,@FP2Valid,@CPSpeed,@CPDirection,@CPValid,@dehydrationSpeed,@dehydrationValid,@TargetTimeH,@TargetTimeMin,@IsTargetTime,@TargetBP,@IsTargetBP,@TargetDP,@IsTargetDP,@TargetSP,@IsTargetSP,@TargetRP,@IsTargetRP,@TargetFP,@IsTargetFP,@Concentration,@SP_Speed,@SP_RapidInjectionValue,@TargetT,@PaccUpper,@PaccLower,@PartUpper,@PartLower,@PvenUpper,@PvenLower,@P1stUpper,@P1stLower,@P2ndUpper,@P2ndLower,@TmpUpper,@TmpLower,@PrePaccLower,@PrePvenUpper,@BloodLeak,@P3rdLower,@P3rdUpper,@LeadBloodSpeed,@LeadBloodTime,@PaccDecrement)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@BPSpeed", MySqlDbType.Double),
					new MySqlParameter("@BPDirection", MySqlDbType.Bit),
					new MySqlParameter("@BPValid", MySqlDbType.Bit),
					new MySqlParameter("@FPSpeed", MySqlDbType.Double),
					new MySqlParameter("@FPDirection", MySqlDbType.Bit),
					new MySqlParameter("@FPValid", MySqlDbType.Bit),
					new MySqlParameter("@DPSpeed", MySqlDbType.Double),
					new MySqlParameter("@DPDirection", MySqlDbType.Bit),
					new MySqlParameter("@DPValid", MySqlDbType.Bit),
					new MySqlParameter("@RPSpeed", MySqlDbType.Double),
					new MySqlParameter("@RPDirection", MySqlDbType.Bit),
					new MySqlParameter("@RPValid", MySqlDbType.Bit),
					new MySqlParameter("@FP2Speed", MySqlDbType.Double),
					new MySqlParameter("@FP2Direction", MySqlDbType.Bit),
					new MySqlParameter("@FP2Valid", MySqlDbType.Bit),
					new MySqlParameter("@CPSpeed", MySqlDbType.Double),
					new MySqlParameter("@CPDirection", MySqlDbType.Bit),
					new MySqlParameter("@CPValid", MySqlDbType.Bit),
					new MySqlParameter("@dehydrationSpeed", MySqlDbType.Double),
					new MySqlParameter("@dehydrationValid", MySqlDbType.Bit),
					new MySqlParameter("@TargetTimeH", MySqlDbType.Int32,11),
					new MySqlParameter("@TargetTimeMin", MySqlDbType.Int32,11),
					new MySqlParameter("@IsTargetTime", MySqlDbType.Bit),
					new MySqlParameter("@TargetBP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetBP", MySqlDbType.Bit),
					new MySqlParameter("@TargetDP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetDP", MySqlDbType.Bit),
					new MySqlParameter("@TargetSP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetSP", MySqlDbType.Bit),
					new MySqlParameter("@TargetRP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetRP", MySqlDbType.Bit),
					new MySqlParameter("@TargetFP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetFP", MySqlDbType.Bit),
					new MySqlParameter("@Concentration", MySqlDbType.Double),
					new MySqlParameter("@SP_Speed", MySqlDbType.Double),
					new MySqlParameter("@SP_RapidInjectionValue", MySqlDbType.Double),
					new MySqlParameter("@TargetT", MySqlDbType.Double),
					new MySqlParameter("@PaccUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PaccLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PartUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PartLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PvenUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PvenLower", MySqlDbType.Int32,11),
					new MySqlParameter("@P1stUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@P1stLower", MySqlDbType.Int32,11),
					new MySqlParameter("@P2ndUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@P2ndLower", MySqlDbType.Int32,11),
					new MySqlParameter("@TmpUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@TmpLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PrePaccLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PrePvenUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@BloodLeak", MySqlDbType.Int32,11),
                    new MySqlParameter("@P3rdLower", MySqlDbType.Int32,11),
                    new MySqlParameter("@P3rdUpper", MySqlDbType.Int32,11),
                               new MySqlParameter("@LeadBloodSpeed", MySqlDbType.Int32,11),
                               new MySqlParameter("@LeadBloodTime", MySqlDbType.Int32,11),
                               new MySqlParameter("@PaccDecrement",MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = model.name;
            parameters[1].Value = model.BPSpeed;
            parameters[2].Value = model.BPDirection;
            parameters[3].Value = model.BPValid;
            parameters[4].Value = model.FPSpeed;
            parameters[5].Value = model.FPDirection;
            parameters[6].Value = model.FPValid;
            parameters[7].Value = model.DPSpeed;
            parameters[8].Value = model.DPDirection;
            parameters[9].Value = model.DPValid;
            parameters[10].Value = model.RPSpeed;
            parameters[11].Value = model.RPDirection;
            parameters[12].Value = model.RPValid;
            parameters[13].Value = model.FP2Speed;
            parameters[14].Value = model.FP2Direction;
            parameters[15].Value = model.FP2Valid;
            parameters[16].Value = model.CPSpeed;
            parameters[17].Value = model.CPDirection;
            parameters[18].Value = model.CPValid;
            parameters[19].Value = model.dehydrationSpeed;
            parameters[20].Value = model.dehydrationValid;
            parameters[21].Value = model.TargetTimeH;
            parameters[22].Value = model.TargetTimeMin;
            parameters[23].Value = model.IsTargetTime;
            parameters[24].Value = model.TargetBP;
            parameters[25].Value = model.IsTargetBP;
            parameters[26].Value = model.TargetDP;
            parameters[27].Value = model.IsTargetDP;
            parameters[28].Value = model.TargetSP;
            parameters[29].Value = model.IsTargetSP;
            parameters[30].Value = model.TargetRP;
            parameters[31].Value = model.IsTargetRP;
            parameters[32].Value = model.TargetFP;
            parameters[33].Value = model.IsTargetFP;
            parameters[34].Value = model.Concentration;
            parameters[35].Value = model.SP_Speed;
            parameters[36].Value = model.SP_RapidInjectionValue;
            parameters[37].Value = model.TargetT;
            parameters[38].Value = model.PaccUpper;
            parameters[39].Value = model.PaccLower;
            parameters[40].Value = model.PartUpper;
            parameters[41].Value = model.PartLower;
            parameters[42].Value = model.PvenUpper;
            parameters[43].Value = model.PvenLower;
            parameters[44].Value = model.P1stUpper;
            parameters[45].Value = model.P1stLower;
            parameters[46].Value = model.P2ndUpper;
            parameters[47].Value = model.P2ndLower;
            parameters[48].Value = model.TmpUpper;
            parameters[49].Value = model.TmpLower;
            parameters[50].Value = model.PrePaccLower;
            parameters[51].Value = model.PrePvenUpper;
            parameters[52].Value = model.BloodLeak;
            parameters[53].Value = model.P3rdLower;
            parameters[54].Value = model.P3rdUpper;
            parameters[55].Value = model.LeadBloodSpeed;
            parameters[56].Value = model.LeadBloodTime;
            parameters[57].Value = model.PaccDecrement;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ALS.Model.treatmentmode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_treatmentmode set ");
            strSql.Append("name=@name,");
            strSql.Append("BPSpeed=@BPSpeed,");
            strSql.Append("BPDirection=@BPDirection,");
            strSql.Append("BPValid=@BPValid,");
            strSql.Append("FPSpeed=@FPSpeed,");
            strSql.Append("FPDirection=@FPDirection,");
            strSql.Append("FPValid=@FPValid,");
            strSql.Append("DPSpeed=@DPSpeed,");
            strSql.Append("DPDirection=@DPDirection,");
            strSql.Append("DPValid=@DPValid,");
            strSql.Append("RPSpeed=@RPSpeed,");
            strSql.Append("RPDirection=@RPDirection,");
            strSql.Append("RPValid=@RPValid,");
            strSql.Append("FP2Speed=@FP2Speed,");
            strSql.Append("FP2Direction=@FP2Direction,");
            strSql.Append("FP2Valid=@FP2Valid,");
            strSql.Append("CPSpeed=@CPSpeed,");
            strSql.Append("CPDirection=@CPDirection,");
            strSql.Append("CPValid=@CPValid,");
            strSql.Append("dehydrationSpeed=@dehydrationSpeed,");
            strSql.Append("dehydrationValid=@dehydrationValid,");
            strSql.Append("TargetTimeH=@TargetTimeH,");
            strSql.Append("TargetTimeMin=@TargetTimeMin,");
            strSql.Append("IsTargetTime=@IsTargetTime,");
            strSql.Append("TargetBP=@TargetBP,");
            strSql.Append("IsTargetBP=@IsTargetBP,");
            strSql.Append("TargetDP=@TargetDP,");
            strSql.Append("IsTargetDP=@IsTargetDP,");
            strSql.Append("TargetSP=@TargetSP,");
            strSql.Append("IsTargetSP=@IsTargetSP,");
            strSql.Append("TargetRP=@TargetRP,");
            strSql.Append("IsTargetRP=@IsTargetRP,");
            strSql.Append("TargetFP=@TargetFP,");
            strSql.Append("IsTargetFP=@IsTargetFP,");
            strSql.Append("Concentration=@Concentration,");
            strSql.Append("SP_Speed=@SP_Speed,");
            strSql.Append("SP_RapidInjectionValue=@SP_RapidInjectionValue,");
            strSql.Append("TargetT=@TargetT,");
            strSql.Append("PaccUpper=@PaccUpper,");
            strSql.Append("PaccLower=@PaccLower,");
            strSql.Append("PartUpper=@PartUpper,");
            strSql.Append("PartLower=@PartLower,");
            strSql.Append("PvenUpper=@PvenUpper,");
            strSql.Append("PvenLower=@PvenLower,");
            strSql.Append("P1stUpper=@P1stUpper,");
            strSql.Append("P1stLower=@P1stLower,");
            strSql.Append("P2ndUpper=@P2ndUpper,");
            strSql.Append("P2ndLower=@P2ndLower,");
            strSql.Append("TmpUpper=@TmpUpper,");
            strSql.Append("TmpLower=@TmpLower,");
            strSql.Append("PrePaccLower=@PrePaccLower,");
            strSql.Append("PrePvenUpper=@PrePvenUpper,");
            strSql.Append("BloodLeak=@BloodLeak,");
            strSql.Append("PrePartUpper=@PrePartUpper,");
            strSql.Append("P3rdLower=@P3rdLower,");
            strSql.Append("P3rdUpper=@P3rdUpper,");
            strSql.Append("LeadBloodSpeed=@LeadBloodSpeed,");
            strSql.Append("LeadBloodTime=@LeadBloodTime,");
            strSql.Append("PaccDecrement=@PaccDecrement");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@BPSpeed", MySqlDbType.Double),
					new MySqlParameter("@BPDirection", MySqlDbType.Bit),
					new MySqlParameter("@BPValid", MySqlDbType.Bit),
					new MySqlParameter("@FPSpeed", MySqlDbType.Double),
					new MySqlParameter("@FPDirection", MySqlDbType.Bit),
					new MySqlParameter("@FPValid", MySqlDbType.Bit),
					new MySqlParameter("@DPSpeed", MySqlDbType.Double),
					new MySqlParameter("@DPDirection", MySqlDbType.Bit),
					new MySqlParameter("@DPValid", MySqlDbType.Bit),
					new MySqlParameter("@RPSpeed", MySqlDbType.Double),
					new MySqlParameter("@RPDirection", MySqlDbType.Bit),
					new MySqlParameter("@RPValid", MySqlDbType.Bit),
					new MySqlParameter("@FP2Speed", MySqlDbType.Double),
					new MySqlParameter("@FP2Direction", MySqlDbType.Bit),
					new MySqlParameter("@FP2Valid", MySqlDbType.Bit),
					new MySqlParameter("@CPSpeed", MySqlDbType.Double),
					new MySqlParameter("@CPDirection", MySqlDbType.Bit),
					new MySqlParameter("@CPValid", MySqlDbType.Bit),
					new MySqlParameter("@dehydrationSpeed", MySqlDbType.Double),
					new MySqlParameter("@dehydrationValid", MySqlDbType.Bit),
					new MySqlParameter("@TargetTimeH", MySqlDbType.Int32,11),
					new MySqlParameter("@TargetTimeMin", MySqlDbType.Int32,11),
					new MySqlParameter("@IsTargetTime", MySqlDbType.Bit),
					new MySqlParameter("@TargetBP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetBP", MySqlDbType.Bit),
					new MySqlParameter("@TargetDP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetDP", MySqlDbType.Bit),
					new MySqlParameter("@TargetSP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetSP", MySqlDbType.Bit),
					new MySqlParameter("@TargetRP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetRP", MySqlDbType.Bit),
					new MySqlParameter("@TargetFP", MySqlDbType.Double),
					new MySqlParameter("@IsTargetFP", MySqlDbType.Bit),
					new MySqlParameter("@Concentration", MySqlDbType.Double),
					new MySqlParameter("@SP_Speed", MySqlDbType.Double),
					new MySqlParameter("@SP_RapidInjectionValue", MySqlDbType.Double),
					new MySqlParameter("@TargetT", MySqlDbType.Double),
					new MySqlParameter("@PaccUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PaccLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PartUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PartLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PvenUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@PvenLower", MySqlDbType.Int32,11),
					new MySqlParameter("@P1stUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@P1stLower", MySqlDbType.Int32,11),
					new MySqlParameter("@P2ndUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@P2ndLower", MySqlDbType.Int32,11),
					new MySqlParameter("@TmpUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@TmpLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PrePaccLower", MySqlDbType.Int32,11),
					new MySqlParameter("@PrePvenUpper", MySqlDbType.Int32,11),
					new MySqlParameter("@BloodLeak", MySqlDbType.Int32,11),
                    new MySqlParameter("@PrePartUpper", MySqlDbType.Int32,11),
                    new MySqlParameter("@P3rdLower", MySqlDbType.Int32,11),
                    new MySqlParameter("@P3rdUpper", MySqlDbType.Int32,11),
                     new MySqlParameter("@LeadBloodSpeed", MySqlDbType.Int32,11),
                      new MySqlParameter("@LeadBloodTime", MySqlDbType.Int32,11),
                        new MySqlParameter("@PaccDecrement", MySqlDbType.Int32,11),
					new MySqlParameter("@ID", MySqlDbType.Int32,20) 
                                          };
            parameters[0].Value = model.name;
            parameters[1].Value = model.BPSpeed;
            parameters[2].Value = model.BPDirection;
            parameters[3].Value = model.BPValid;
            parameters[4].Value = model.FPSpeed;
            parameters[5].Value = model.FPDirection;
            parameters[6].Value = model.FPValid;
            parameters[7].Value = model.DPSpeed;
            parameters[8].Value = model.DPDirection;
            parameters[9].Value = model.DPValid;
            parameters[10].Value = model.RPSpeed;
            parameters[11].Value = model.RPDirection;
            parameters[12].Value = model.RPValid;
            parameters[13].Value = model.FP2Speed;
            parameters[14].Value = model.FP2Direction;
            parameters[15].Value = model.FP2Valid;
            parameters[16].Value = model.CPSpeed;
            parameters[17].Value = model.CPDirection;
            parameters[18].Value = model.CPValid;
            parameters[19].Value = model.dehydrationSpeed;
            parameters[20].Value = model.dehydrationValid;
            parameters[21].Value = model.TargetTimeH;
            parameters[22].Value = model.TargetTimeMin;
            parameters[23].Value = model.IsTargetTime;
            parameters[24].Value = model.TargetBP;
            parameters[25].Value = model.IsTargetBP;
            parameters[26].Value = model.TargetDP;
            parameters[27].Value = model.IsTargetDP;
            parameters[28].Value = model.TargetSP;
            parameters[29].Value = model.IsTargetSP;
            parameters[30].Value = model.TargetRP;
            parameters[31].Value = model.IsTargetRP;
            parameters[32].Value = model.TargetFP;
            parameters[33].Value = model.IsTargetFP;
            parameters[34].Value = model.Concentration;
            parameters[35].Value = model.SP_Speed;
            parameters[36].Value = model.SP_RapidInjectionValue;
            parameters[37].Value = model.TargetT;
            parameters[38].Value = model.PaccUpper;
            parameters[39].Value = model.PaccLower;
            parameters[40].Value = model.PartUpper;
            parameters[41].Value = model.PartLower;
            parameters[42].Value = model.PvenUpper;
            parameters[43].Value = model.PvenLower;
            parameters[44].Value = model.P1stUpper;
            parameters[45].Value = model.P1stLower;
            parameters[46].Value = model.P2ndUpper;
            parameters[47].Value = model.P2ndLower;
            parameters[48].Value = model.TmpUpper;
            parameters[49].Value = model.TmpLower;
            parameters[50].Value = model.PrePaccLower;
            parameters[51].Value = model.PrePvenUpper;
            parameters[52].Value = model.BloodLeak;
            parameters[53].Value = model.PrePartUpper;
            parameters[54].Value = model.P3rdLower;
            parameters[55].Value = model.P3rdUpper;
            parameters[56].Value = model.LeadBloodSpeed;
            parameters[57].Value = model.LeadBloodTime;
            parameters[58].Value = model.PaccDecrement;
            parameters[59].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_treatmentmode ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_treatmentmode ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.treatmentmode GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,name,BPSpeed,BPDirection,BPValid,FPSpeed,FPDirection,FPValid,DPSpeed,DPDirection,DPValid,RPSpeed,RPDirection,RPValid,FP2Speed,FP2Direction,FP2Valid,CPSpeed,CPDirection,CPValid,dehydrationSpeed,dehydrationValid,TargetTimeH,TargetTimeMin,IsTargetTime,TargetBP,IsTargetBP,TargetDP,IsTargetDP,TargetSP,IsTargetSP,TargetRP,IsTargetRP,TargetFP,IsTargetFP,Concentration,SP_Speed,SP_RapidInjectionValue,TargetT,PaccUpper,PaccLower,PartUpper,PartLower,PvenUpper,PvenLower,P1stUpper,P1stLower,P2ndUpper,P2ndLower,TmpUpper,TmpLower,PrePaccLower,PrePvenUpper,BloodLeak,PrePartUpper,P3rdLower,P3rdUpper,LeadBloodSpeed,LeadBloodTime,PaccDecrement from tb_treatmentmode ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.treatmentmode model = new ALS.Model.treatmentmode();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public ALS.Model.treatmentmode GetModel(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,name,BPSpeed,BPDirection,BPValid,FPSpeed,FPDirection,FPValid,DPSpeed,DPDirection,DPValid,RPSpeed,RPDirection,RPValid,FP2Speed,FP2Direction,FP2Valid,CPSpeed,CPDirection,CPValid,dehydrationSpeed,dehydrationValid,TargetTimeH,TargetTimeMin,IsTargetTime,TargetBP,IsTargetBP,TargetDP,IsTargetDP,TargetSP,IsTargetSP,TargetRP,IsTargetRP,TargetFP,IsTargetFP,Concentration,SP_Speed,SP_RapidInjectionValue,TargetT,PaccUpper,PaccLower,PartUpper,PartLower,PvenUpper,PvenLower,P1stUpper,P1stLower,P2ndUpper,P2ndLower,TmpUpper,TmpLower,PrePaccLower,PrePvenUpper,BloodLeak,PrePartUpper,P3rdLower,P3rdUpper,LeadBloodSpeed,LeadBloodTime,PaccDecrement from tb_treatmentmode ");
            strSql.Append(" where name=@name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar)
			};
            parameters[0].Value = name;

            ALS.Model.treatmentmode model = new ALS.Model.treatmentmode();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.treatmentmode DataRowToModel(DataRow row)
        {
            ALS.Model.treatmentmode model = new ALS.Model.treatmentmode();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                model.BPSpeed=Convert.ToDouble(row["BPSpeed"].ToString());
                if (row["BPDirection"] != null && row["BPDirection"].ToString() != "")
                {
                    if ((row["BPDirection"].ToString() == "1") || (row["BPDirection"].ToString().ToLower() == "true"))
                    {
                        model.BPDirection = true;
                    }
                    else
                    {
                        model.BPDirection = false;
                    }
                }
                if (row["BPValid"] != null && row["BPValid"].ToString() != "")
                {
                    if ((row["BPValid"].ToString() == "1") || (row["BPValid"].ToString().ToLower() == "true"))
                    {
                        model.BPValid = true;
                    }
                    else
                    {
                        model.BPValid = false;
                    }
                }
                model.FPSpeed=Convert.ToDouble(row["FPSpeed"].ToString());
                if (row["FPDirection"] != null && row["FPDirection"].ToString() != "")
                {
                    if ((row["FPDirection"].ToString() == "1") || (row["FPDirection"].ToString().ToLower() == "true"))
                    {
                        model.FPDirection = true;
                    }
                    else
                    {
                        model.FPDirection = false;
                    }
                }
                if (row["FPValid"] != null && row["FPValid"].ToString() != "")
                {
                    if ((row["FPValid"].ToString() == "1") || (row["FPValid"].ToString().ToLower() == "true"))
                    {
                        model.FPValid = true;
                    }
                    else
                    {
                        model.FPValid = false;
                    }
                }
                model.DPSpeed = Convert.ToDouble(row["DPSpeed"].ToString());
                if (row["DPDirection"] != null && row["DPDirection"].ToString() != "")
                {
                    if ((row["DPDirection"].ToString() == "1") || (row["DPDirection"].ToString().ToLower() == "true"))
                    {
                        model.DPDirection = true;
                    }
                    else
                    {
                        model.DPDirection = false;
                    }
                }
                if (row["DPValid"] != null && row["DPValid"].ToString() != "")
                {
                    if ((row["DPValid"].ToString() == "1") || (row["DPValid"].ToString().ToLower() == "true"))
                    {
                        model.DPValid = true;
                    }
                    else
                    {
                        model.DPValid = false;
                    }
                }
                model.RPSpeed = Convert.ToDouble(row["RPSpeed"].ToString());
                if (row["RPDirection"] != null && row["RPDirection"].ToString() != "")
                {
                    if ((row["RPDirection"].ToString() == "1") || (row["RPDirection"].ToString().ToLower() == "true"))
                    {
                        model.RPDirection = true;
                    }
                    else
                    {
                        model.RPDirection = false;
                    }
                }
                if (row["RPValid"] != null && row["RPValid"].ToString() != "")
                {
                    if ((row["RPValid"].ToString() == "1") || (row["RPValid"].ToString().ToLower() == "true"))
                    {
                        model.RPValid = true;
                    }
                    else
                    {
                        model.RPValid = false;
                    }
                }
                model.FP2Speed = Convert.ToDouble(row["FP2Speed"].ToString());
                if (row["FP2Direction"] != null && row["FP2Direction"].ToString() != "")
                {
                    if ((row["FP2Direction"].ToString() == "1") || (row["FP2Direction"].ToString().ToLower() == "true"))
                    {
                        model.FP2Direction = true;
                    }
                    else
                    {
                        model.FP2Direction = false;
                    }
                }
                if (row["FP2Valid"] != null && row["FP2Valid"].ToString() != "")
                {
                    if ((row["FP2Valid"].ToString() == "1") || (row["FP2Valid"].ToString().ToLower() == "true"))
                    {
                        model.FP2Valid = true;
                    }
                    else
                    {
                        model.FP2Valid = false;
                    }
                }
                model.CPSpeed = Convert.ToDouble(row["CPSpeed"].ToString());
                if (row["CPDirection"] != null && row["CPDirection"].ToString() != "")
                {
                    if ((row["CPDirection"].ToString() == "1") || (row["CPDirection"].ToString().ToLower() == "true"))
                    {
                        model.CPDirection = true;
                    }
                    else
                    {
                        model.CPDirection = false;
                    }
                }
                if (row["CPValid"] != null && row["CPValid"].ToString() != "")
                {
                    if ((row["CPValid"].ToString() == "1") || (row["CPValid"].ToString().ToLower() == "true"))
                    {
                        model.CPValid = true;
                    }
                    else
                    {
                        model.CPValid = false;
                    }
                }
                model.dehydrationSpeed = Convert.ToDouble(row["dehydrationSpeed"].ToString());
                if (row["dehydrationValid"] != null && row["dehydrationValid"].ToString() != "")
                {
                    if ((row["dehydrationValid"].ToString() == "1") || (row["dehydrationValid"].ToString().ToLower() == "true"))
                    {
                        model.dehydrationValid = true;
                    }
                    else
                    {
                        model.dehydrationValid = false;
                    }
                }
                if (row["TargetTimeH"] != null && row["TargetTimeH"].ToString() != "")
                {
                    model.TargetTimeH = int.Parse(row["TargetTimeH"].ToString());
                }
                if (row["TargetTimeMin"] != null && row["TargetTimeMin"].ToString() != "")
                {
                    model.TargetTimeMin = int.Parse(row["TargetTimeMin"].ToString());
                }
                if (row["IsTargetTime"] != null && row["IsTargetTime"].ToString() != "")
                {
                    if ((row["IsTargetTime"].ToString() == "1") || (row["IsTargetTime"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetTime = true;
                    }
                    else
                    {
                        model.IsTargetTime = false;
                    }
                }
                model.TargetBP = Convert.ToDouble(row["TargetBP"].ToString());
                if (row["IsTargetBP"] != null && row["IsTargetBP"].ToString() != "")
                {
                    if ((row["IsTargetBP"].ToString() == "1") || (row["IsTargetBP"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetBP = true;
                    }
                    else
                    {
                        model.IsTargetBP = false;
                    }
                }
                model.TargetDP = Convert.ToDouble(row["TargetDP"].ToString());
                if (row["IsTargetDP"] != null && row["IsTargetDP"].ToString() != "")
                {
                    if ((row["IsTargetDP"].ToString() == "1") || (row["IsTargetDP"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetDP = true;
                    }
                    else
                    {
                        model.IsTargetDP = false;
                    }
                }
                model.TargetSP = Convert.ToDouble(row["TargetSP"].ToString());
                if (row["IsTargetSP"] != null && row["IsTargetSP"].ToString() != "")
                {
                    if ((row["IsTargetSP"].ToString() == "1") || (row["IsTargetSP"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetSP = true;
                    }
                    else
                    {
                        model.IsTargetSP = false;
                    }
                }
                model.TargetRP = Convert.ToDouble(row["TargetRP"].ToString());
                if (row["IsTargetRP"] != null && row["IsTargetRP"].ToString() != "")
                {
                    if ((row["IsTargetRP"].ToString() == "1") || (row["IsTargetRP"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetRP = true;
                    }
                    else
                    {
                        model.IsTargetRP = false;
                    }
                }
                model.TargetFP = Convert.ToDouble(row["TargetFP"].ToString());
                if (row["IsTargetFP"] != null && row["IsTargetFP"].ToString() != "")
                {
                    if ((row["IsTargetFP"].ToString() == "1") || (row["IsTargetFP"].ToString().ToLower() == "true"))
                    {
                        model.IsTargetFP = true;
                    }
                    else
                    {
                        model.IsTargetFP = false;
                    }
                }
                model.Concentration=Convert.ToDouble(row["Concentration"].ToString());
                model.SP_Speed=Convert.ToDouble(row["SP_Speed"].ToString());
                model.SP_RapidInjectionValue=Convert.ToDouble(row["SP_RapidInjectionValue"].ToString());
                model.TargetT=Convert.ToDouble(row["TargetT"].ToString());
                if (row["PaccUpper"] != null && row["PaccUpper"].ToString() != "")
                {
                    model.PaccUpper = int.Parse(row["PaccUpper"].ToString());
                }
                if (row["PaccLower"] != null && row["PaccLower"].ToString() != "")
                {
                    model.PaccLower = int.Parse(row["PaccLower"].ToString());
                }
                if (row["PartUpper"] != null && row["PartUpper"].ToString() != "")
                {
                    model.PartUpper = int.Parse(row["PartUpper"].ToString());
                }
                if (row["PartLower"] != null && row["PartLower"].ToString() != "")
                {
                    model.PartLower = int.Parse(row["PartLower"].ToString());
                }
                if (row["PvenUpper"] != null && row["PvenUpper"].ToString() != "")
                {
                    model.PvenUpper = int.Parse(row["PvenUpper"].ToString());
                }
                if (row["PvenLower"] != null && row["PvenLower"].ToString() != "")
                {
                    model.PvenLower = int.Parse(row["PvenLower"].ToString());
                }
                if (row["P1stUpper"] != null && row["P1stUpper"].ToString() != "")
                {
                    model.P1stUpper = int.Parse(row["P1stUpper"].ToString());
                }
                if (row["P1stLower"] != null && row["P1stLower"].ToString() != "")
                {
                    model.P1stLower = int.Parse(row["P1stLower"].ToString());
                }
                if (row["P2ndUpper"] != null && row["P2ndUpper"].ToString() != "")
                {
                    model.P2ndUpper = int.Parse(row["P2ndUpper"].ToString());
                }
                if (row["P2ndLower"] != null && row["P2ndLower"].ToString() != "")
                {
                    model.P2ndLower = int.Parse(row["P2ndLower"].ToString());
                }
                if (row["TmpUpper"] != null && row["TmpUpper"].ToString() != "")
                {
                    model.TmpUpper = int.Parse(row["TmpUpper"].ToString());
                }
                if (row["TmpLower"] != null && row["TmpLower"].ToString() != "")
                {
                    model.TmpLower = int.Parse(row["TmpLower"].ToString());
                }
                if (row["PrePaccLower"] != null && row["PrePaccLower"].ToString() != "")
                {
                    model.PrePaccLower = int.Parse(row["PrePaccLower"].ToString());
                }
                if (row["PrePvenUpper"] != null && row["PrePvenUpper"].ToString() != "")
                {
                    model.PrePvenUpper = int.Parse(row["PrePvenUpper"].ToString());
                }
                if (row["BloodLeak"] != null && row["BloodLeak"].ToString() != "")
                {
                    model.BloodLeak = int.Parse(row["BloodLeak"].ToString());
                }
                if (row["PrePartUpper"] != null && row["PrePartUpper"].ToString() != "")
                {
                    model.PrePartUpper = int.Parse(row["PrePartUpper"].ToString());
                }
                if (row["P3rdLower"] != null && row["P3rdLower"].ToString() != "")
                {
                    model.P3rdLower = int.Parse(row["P3rdLower"].ToString());
                }
                if (row["P3rdUpper"] != null && row["P3rdUpper"].ToString() != "")
                {
                    model.P3rdUpper = int.Parse(row["P3rdUpper"].ToString());
                }
                if (row["LeadBloodSpeed"] != null && row["LeadBloodSpeed"].ToString() != "")
                {
                    model.LeadBloodSpeed = int.Parse(row["LeadBloodSpeed"].ToString());
                }
                if (row["LeadBloodTime"] != null && row["LeadBloodTime"].ToString() != "")
                {
                    model.LeadBloodTime = int.Parse(row["LeadBloodTime"].ToString());
                }
                if (row["PaccDecrement"] != null && row["PaccDecrement"].ToString() != "")
                {
                    model.PaccDecrement = int.Parse(row["PaccDecrement"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,name,BPSpeed,BPDirection,BPValid,FPSpeed,FPDirection,FPValid,DPSpeed,DPDirection,DPValid,RPSpeed,RPDirection,RPValid,FP2Speed,FP2Direction,FP2Valid,CPSpeed,CPDirection,CPValid,dehydrationSpeed,dehydrationValid,TargetTimeH,TargetTimeMin,IsTargetTime,TargetBP,IsTargetBP,TargetDP,IsTargetDP,TargetSP,IsTargetSP,TargetRP,IsTargetRP,TargetFP,IsTargetFP,Concentration,SP_Speed,SP_RapidInjectionValue,TargetT,PaccUpper,PaccLower,PartUpper,PartLower,PvenUpper,PvenLower,P1stUpper,P1stLower,P2ndUpper,P2ndLower,TmpUpper,TmpLower,PrePaccLower,PrePvenUpper,BloodLeak,P3rdLower,P3rdUpper,LeadBloodSpeed,LeadBloodTime,PaccDecrement ");
            strSql.Append(" FROM tb_treatmentmode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_treatmentmode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_treatmentmode T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_treatmentmode";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

