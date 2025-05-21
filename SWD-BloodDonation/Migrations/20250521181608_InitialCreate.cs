using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD_BloodDonation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodComponent",
                columns: table => new
                {
                    blood_component_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BloodCom__14A61BEFD91EAD6D", x => x.blood_component_id);
                });

            migrationBuilder.CreateTable(
                name: "BloodType",
                columns: table => new
                {
                    blood_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    rh_factor = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BloodTyp__56FFB8C8F2AED018", x => x.blood_type_id);
                });

            migrationBuilder.CreateTable(
                name: "BloodInventory",
                columns: table => new
                {
                    inventory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    blood_component_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    inventory_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BloodInv__B59ACC49359E3CED", x => x.inventory_id);
                    table.ForeignKey(
                        name: "FK__BloodInve__blood__59FA5E80",
                        column: x => x.blood_type_id,
                        principalTable: "BloodType",
                        principalColumn: "blood_type_id");
                    table.ForeignKey(
                        name: "FK__BloodInve__blood__5AEE82B9",
                        column: x => x.blood_component_id,
                        principalTable: "BloodComponent",
                        principalColumn: "blood_component_id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    blood_component_id = table.Column<int>(type: "int", nullable: true),
                    user_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    role = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    identification = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B9BE370F82B4A317", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__User__blood_comp__403A8C7D",
                        column: x => x.blood_component_id,
                        principalTable: "BloodComponent",
                        principalColumn: "blood_component_id");
                    table.ForeignKey(
                        name: "FK__User__blood_type__3F466844",
                        column: x => x.blood_type_id,
                        principalTable: "BloodType",
                        principalColumn: "blood_type_id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    img = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BlogPost__3ED787668B69A509", x => x.post_id);
                    table.ForeignKey(
                        name: "FK__BlogPost__user_i__6EF57B66",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "BloodRequest",
                columns: table => new
                {
                    blood_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    blood_component_id = table.Column<int>(type: "int", nullable: true),
                    is_emergency = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    fulfilled = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    fulfilled_source = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    height_cm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    weight_kg = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    medical_history = table.Column<string>(type: "text", nullable: true),
                    patient_condition = table.Column<string>(type: "text", nullable: true),
                    reason_for_request = table.Column<string>(type: "text", nullable: true),
                    urgency_level = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BloodReq__0F0E510DE22697BE", x => x.blood_request_id);
                    table.ForeignKey(
                        name: "FK__BloodRequ__blood__52593CB8",
                        column: x => x.blood_type_id,
                        principalTable: "BloodType",
                        principalColumn: "blood_type_id");
                    table.ForeignKey(
                        name: "FK__BloodRequ__blood__534D60F1",
                        column: x => x.blood_component_id,
                        principalTable: "BloodComponent",
                        principalColumn: "blood_component_id");
                    table.ForeignKey(
                        name: "FK__BloodRequ__user___5165187F",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "DonationHistory",
                columns: table => new
                {
                    donation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    blood_component_id = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    volume_ml = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donation__296B91DCE12F47BB", x => x.donation_id);
                    table.ForeignKey(
                        name: "FK__DonationH__blood__45F365D3",
                        column: x => x.blood_type_id,
                        principalTable: "BloodType",
                        principalColumn: "blood_type_id");
                    table.ForeignKey(
                        name: "FK__DonationH__blood__46E78A0C",
                        column: x => x.blood_component_id,
                        principalTable: "BloodComponent",
                        principalColumn: "blood_component_id");
                    table.ForeignKey(
                        name: "FK__DonationH__user___44FF419A",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "DonationRequest",
                columns: table => new
                {
                    donate_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    blood_component_id = table.Column<int>(type: "int", nullable: true),
                    preferred_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    height_cm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    weight_kg = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    medical_history = table.Column<string>(type: "text", nullable: true),
                    general_health_status = table.Column<string>(type: "text", nullable: true),
                    hemoglobin_level = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    last_donation_date = table.Column<DateOnly>(type: "date", nullable: true),
                    blood_pressure = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    pulse_rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donation__D517757ABCD67DE3", x => x.donate_request_id);
                    table.ForeignKey(
                        name: "FK__DonationR__blood__4BAC3F29",
                        column: x => x.blood_type_id,
                        principalTable: "BloodType",
                        principalColumn: "blood_type_id");
                    table.ForeignKey(
                        name: "FK__DonationR__blood__4CA06362",
                        column: x => x.blood_component_id,
                        principalTable: "BloodComponent",
                        principalColumn: "blood_component_id");
                    table.ForeignKey(
                        name: "FK__DonationR__user___4AB81AF0",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    sent_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__E059842F40F16515", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__Notificat__user___6A30C649",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "BloodRequestInventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_request_id = table.Column<int>(type: "int", nullable: true),
                    inventory_id = table.Column<int>(type: "int", nullable: true),
                    quantity_unit = table.Column<int>(type: "int", nullable: true),
                    quantity_allocated = table.Column<int>(type: "int", nullable: true),
                    allocated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    allocated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BloodReq__3213E83F6F3F0B08", x => x.id);
                    table.ForeignKey(
                        name: "FK__BloodRequ__alloc__619B8048",
                        column: x => x.allocated_by,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__BloodRequ__blood__5EBF139D",
                        column: x => x.blood_request_id,
                        principalTable: "BloodRequest",
                        principalColumn: "blood_request_id");
                    table.ForeignKey(
                        name: "FK__BloodRequ__inven__5FB337D6",
                        column: x => x.inventory_id,
                        principalTable: "BloodInventory",
                        principalColumn: "inventory_id");
                });

            migrationBuilder.CreateTable(
                name: "RequestMatch",
                columns: table => new
                {
                    match_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_request_id = table.Column<int>(type: "int", nullable: true),
                    donation_request_id = table.Column<int>(type: "int", nullable: true),
                    match_status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    scheduled_date = table.Column<DateOnly>(type: "date", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RequestM__9D7FCBA3366FE302", x => x.match_id);
                    table.ForeignKey(
                        name: "FK__RequestMa__blood__6477ECF3",
                        column: x => x.blood_request_id,
                        principalTable: "BloodRequest",
                        principalColumn: "blood_request_id");
                    table.ForeignKey(
                        name: "FK__RequestMa__donat__656C112C",
                        column: x => x.donation_request_id,
                        principalTable: "DonationRequest",
                        principalColumn: "donate_request_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_user_id",
                table: "BlogPost",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__BloodCom__72E12F1BC76DA3F1",
                table: "BloodComponent",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BloodInventory_blood_component_id",
                table: "BloodInventory",
                column: "blood_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodInventory_blood_type_id",
                table: "BloodInventory",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_blood_component_id",
                table: "BloodRequest",
                column: "blood_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_blood_type_id",
                table: "BloodRequest",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_user_id",
                table: "BloodRequest",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestInventory_allocated_by",
                table: "BloodRequestInventory",
                column: "allocated_by");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestInventory_blood_request_id",
                table: "BloodRequestInventory",
                column: "blood_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestInventory_inventory_id",
                table: "BloodRequestInventory",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_blood_component_id",
                table: "DonationHistory",
                column: "blood_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_blood_type_id",
                table: "DonationHistory",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_user_id",
                table: "DonationHistory",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequest_blood_component_id",
                table: "DonationRequest",
                column: "blood_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequest_blood_type_id",
                table: "DonationRequest",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequest_user_id",
                table: "DonationRequest",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_user_id",
                table: "Notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMatch_blood_request_id",
                table: "RequestMatch",
                column: "blood_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMatch_donation_request_id",
                table: "RequestMatch",
                column: "donation_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_blood_component_id",
                table: "User",
                column: "blood_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_blood_type_id",
                table: "User",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__User__AAA7C1F571AA5E41",
                table: "User",
                column: "identification",
                unique: true,
                filter: "[identification] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__User__AB6E616478514D0E",
                table: "User",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "BloodRequestInventory");

            migrationBuilder.DropTable(
                name: "DonationHistory");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RequestMatch");

            migrationBuilder.DropTable(
                name: "BloodInventory");

            migrationBuilder.DropTable(
                name: "BloodRequest");

            migrationBuilder.DropTable(
                name: "DonationRequest");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BloodComponent");

            migrationBuilder.DropTable(
                name: "BloodType");
        }
    }
}
