using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class PersonAddAddress
    {
        public int PersonId
        {
            get;
            set;
        }
        public string personName { get; set; }
        List<row> row { get; set; }
        public  PersonAddAddress(){}
        public PersonAddAddress(int PersonId,string personName,List<row>row) {
            this.PersonId = PersonId;
            this.personName = personName;
            this.row = row;
        }
    }
    public class row 
    {
        public int id{get;set;}
        public string columnName{get;set;}
        List<log> log{get;set;}
        public row(){
        }
        public row(int id,string columnName,List<log>log){
            this.id = id;
            this.columnName=columnName;
            this.log=log;
        }
    }
    public class log{
        public int id{get;set;}
        public string content{get;set;}
        public log(){
        
        }
        public log(int id,string content){
            this.id = id;
            this.content=content;
        }
    }
}