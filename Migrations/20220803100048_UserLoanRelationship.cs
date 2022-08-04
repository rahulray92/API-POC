using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_POC.Migrations
{
    public partial class UserLoanRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.AddColumn<int>(name:"UserId",table:"Loans",type:"int",nullable:true);
migrationBuilder.CreateIndex(name:"IX_Loans_UserId",table:"Loans",column:"UserId");
migrationBuilder.AddForeignKey(name:"FK_Loans_Users_UserId",table:"Loans",column:"UserId",principalTable:"Users",principalColumn:"Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name:"FK_Loans_Users_UserId",
                table:"Loans"
            );
             migrationBuilder.DropIndex(
                name:"IX_Loans_UserId",
                table:"Loans"
            );
            migrationBuilder.DropColumn(
                name:"UserId",
                table:"Loans"
            );
        }
    }
}
