using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoatFarm.Management.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    IdentityDescription = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AvailableStatus = table.Column<int>(type: "integer", nullable: false),
                    TagNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DateAddedUTC = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FarmId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 10, nullable: false),
                    TagNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IsFreeToUse = table.Column<bool>(type: "boolean", nullable: false),
                    FarmId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Farm",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[] { new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), "Sumarga Farm - Ramkot", new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3") });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "FarmId", "IsFreeToUse", "TagNumber" },
                values: new object[,]
                {
                    { new Guid("0115ce68-2ae8-446f-ade1-e6ac55008faa"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "057" },
                    { new Guid("0190664b-d774-44e2-9d03-03dc31d4d0ee"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "062" },
                    { new Guid("032858ac-44b0-4309-b766-8f0a045ae5da"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "001" },
                    { new Guid("0451dec8-b463-4d5b-a146-adea138ac6fb"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "078" },
                    { new Guid("04c158d9-ce7c-458d-a13e-7a598303f06d"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "050" },
                    { new Guid("0570ad99-3497-47b5-b077-cfeb472affd3"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "027" },
                    { new Guid("08fd2f06-0f44-4c21-a2da-80a789057db1"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "037" },
                    { new Guid("0920584d-5412-487b-b892-18153529cc3b"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "081" },
                    { new Guid("094d4f01-30dc-479b-83be-376e80c0a17c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "028" },
                    { new Guid("0a4faf59-1f26-48a5-af3d-1589157809d3"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "008" },
                    { new Guid("0d2cf0c9-2b64-4021-afa5-8f236f3e8569"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "012" },
                    { new Guid("0e852f8e-0a91-4399-ac4a-57a2dbe6829e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "042" },
                    { new Guid("1864093d-7fe2-49e0-97de-bb3e1c5ff242"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "053" },
                    { new Guid("186c6740-32b5-4029-a3fc-c4226ee9cba9"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "074" },
                    { new Guid("198e0b6d-5530-4b50-a2a8-977c6dbe8026"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "015" },
                    { new Guid("1a4c0d76-2ea3-4022-b54e-fae80dcd7734"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "016" },
                    { new Guid("1cefb659-0b40-4108-a422-21e7c4b8e2bf"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "004" },
                    { new Guid("1f458f46-a06c-4588-beb4-e871b643d137"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "083" },
                    { new Guid("205f45a4-4077-4758-a2f4-a6ccabacd2af"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "077" },
                    { new Guid("217cde3b-ae4f-4f1a-963e-707fb44a8120"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "019" },
                    { new Guid("23fe7156-e357-47f2-80b1-6d1e83484aea"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "024" },
                    { new Guid("2a02c26b-390b-4a0b-81aa-0f61d47f100a"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "096" },
                    { new Guid("2ebd212a-4211-4114-af26-02adb98e9904"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "070" },
                    { new Guid("2ff5d8ea-2d11-4a32-b51b-6582d9a86a36"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "014" },
                    { new Guid("32b6bc13-6260-4bd4-a98a-6eceb392fb1a"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "086" },
                    { new Guid("348dba5f-02cb-4bb2-85f3-2bddc73075e4"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "009" },
                    { new Guid("3f25ea0d-3a3a-48ba-b7a3-319c5bc175c8"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "041" },
                    { new Guid("419e7c8f-7a65-4543-bc52-2e343349e318"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "082" },
                    { new Guid("466d5f73-a3a5-41fc-9adf-e02e08527a8f"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "049" },
                    { new Guid("46e08543-e6c4-4181-8115-6f3d80335221"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "034" },
                    { new Guid("4aaa8412-b03b-448d-99f2-801d443647be"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "059" },
                    { new Guid("503aabbc-7f64-4811-bf72-96aeb4ddb20c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "032" },
                    { new Guid("525f169f-26d2-4635-a4b1-f25a0b940cd8"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "040" },
                    { new Guid("527ffd9a-1ac8-4990-b908-dbbe08f45c90"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "047" },
                    { new Guid("5513123e-ab48-486c-8abe-4ed6708b2aac"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "064" },
                    { new Guid("552bfb5e-267c-445a-8435-63e0fc8e0660"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "089" },
                    { new Guid("557ba7ff-6f12-40f6-a906-e0113bd65cb5"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "095" },
                    { new Guid("5c1222cf-7482-4e20-b38d-44820c0264fb"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "067" },
                    { new Guid("5c801ff3-202e-4872-a87a-32510368780e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "061" },
                    { new Guid("5cb8e013-f810-452c-b213-dbcf2a5629a6"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "087" },
                    { new Guid("5ffc6ee6-112c-43f5-82a6-ba4e4dbab0e7"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "020" },
                    { new Guid("620323af-a57d-483f-bc05-69145482be88"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "044" },
                    { new Guid("6803d41d-cf75-47a2-8f68-fdbd663f11b9"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "094" },
                    { new Guid("6e9771bc-a3db-42f3-93a9-274f227315cf"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "075" },
                    { new Guid("71b30c70-8130-435e-b059-e9f860d8af7c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "060" },
                    { new Guid("71f0cb98-0664-4ab7-b232-860fb9b7e084"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "063" },
                    { new Guid("72a97e33-219c-48d7-884b-0b4dc9bb6c9e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "030" },
                    { new Guid("7365fdc6-ab88-4a49-a274-f2d0a4c913b8"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "026" },
                    { new Guid("7a0708ed-d0a4-450a-ad22-cbfa1feb734a"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "036" },
                    { new Guid("7ae92b7f-eeb0-40f3-a845-8a716125f961"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "080" },
                    { new Guid("7f53eb6a-dcd7-4285-9224-4431930db588"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "071" },
                    { new Guid("8256f1cc-d9b2-4497-8b05-4f7b1b9db46a"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "029" },
                    { new Guid("861bf4c8-552e-4d80-bd45-dadd1c7dd5ba"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "021" },
                    { new Guid("87def534-6eb7-438f-9ef8-34fb4594531d"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "011" },
                    { new Guid("8b757f57-ccdd-4e82-8049-7c62c752c6c2"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "058" },
                    { new Guid("8b9cab41-c92b-46ff-aa34-eff916c21c5c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "068" },
                    { new Guid("8c17e569-66da-4244-8314-25d433a06a3f"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "098" },
                    { new Guid("8d667ded-e3f4-4c90-8f72-52c3d16ef282"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "023" },
                    { new Guid("9191f301-a65b-49a7-b98c-4b022bfc4012"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "031" },
                    { new Guid("92e4ac72-ba43-49df-8d76-edb12e8101ca"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "065" },
                    { new Guid("953e91f3-59e7-4036-bbf8-cbab7b0c98dd"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "018" },
                    { new Guid("95e9d0c0-e1cb-40e4-b9d5-4e68237da5f8"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "002" },
                    { new Guid("97ffef6b-0323-475d-941b-362280d341ac"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "052" },
                    { new Guid("9875f2ec-d411-400e-a0da-1c038c63679e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "046" },
                    { new Guid("99c64eda-cc50-4d27-ae0c-04732339aeee"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "035" },
                    { new Guid("9b0dd1a4-8b03-4029-8982-7fb48b889a53"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "025" },
                    { new Guid("a506b4b8-a4f0-412f-a0fd-655c8237f23d"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "054" },
                    { new Guid("a54df46d-1874-4dcb-a474-f7983449ba9e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "038" },
                    { new Guid("a7be25c1-8257-40df-8148-396e0b65e4f4"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "091" },
                    { new Guid("a96d98cd-c520-4f34-84d5-25a2d47aef82"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "097" },
                    { new Guid("aa2c2e60-8a10-416a-a8d0-1c800b8b086c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "084" },
                    { new Guid("ac418eda-7ce8-41a5-a1ea-211ea005e7a1"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "056" },
                    { new Guid("ad8abc9b-563e-44d2-9530-9c7ee1125d4f"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "099" },
                    { new Guid("aebdc35f-71d5-4169-af99-4ff5e6e151c0"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "090" },
                    { new Guid("aebf8009-d0bb-451f-b82a-d5a4973fd19c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "079" },
                    { new Guid("b01e3558-b783-4be3-a49e-f4e04d96696f"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "048" },
                    { new Guid("b09e7e50-ce4b-46ea-9527-276c86d9777d"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "055" },
                    { new Guid("b3ea2e8e-60a3-47b2-b8a7-a1d093d8e19e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "022" },
                    { new Guid("b489035d-c495-4d57-af43-f051a0533bce"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "003" },
                    { new Guid("b9763e79-d181-4fd9-8b9a-2d780bfa422a"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "092" },
                    { new Guid("ba1c68aa-a0f9-4445-9a61-b73656949ae6"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "006" },
                    { new Guid("bb4bb404-3142-4165-910c-38f32d0c36d7"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "088" },
                    { new Guid("c3f17e70-5adf-479e-87ba-e83999defa8c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "069" },
                    { new Guid("c70ed91e-a42a-4632-a58f-9038ef7d00c9"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "093" },
                    { new Guid("c9cd701e-aa6c-4ff5-ad54-8351ff57438c"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "085" },
                    { new Guid("cceb1c25-10f6-4865-962d-9547c0eb5afd"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "076" },
                    { new Guid("cdc37ea2-6c5b-40c1-b0f1-2efa7ce910af"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "013" },
                    { new Guid("ce6a661d-09ee-4b85-93b8-1af0327f1e51"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "005" },
                    { new Guid("ceb20293-963b-4fc9-b617-b871356a8739"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "039" },
                    { new Guid("dbbf62af-220f-45d9-9be9-761d512074ea"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "066" },
                    { new Guid("de95b584-4855-4ee5-ba2c-4596bfeed583"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "017" },
                    { new Guid("e3ec5c10-884c-46c6-8975-29fe89c004c9"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "010" },
                    { new Guid("e5091353-1fcb-4675-9961-80bd1f2214a7"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "043" },
                    { new Guid("e54bc1b7-129e-4b63-9f32-fbe560e47063"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "045" },
                    { new Guid("ea68dc3c-246a-4be1-b893-c96cd050570e"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "072" },
                    { new Guid("ed455214-be0f-49e6-8e25-d21ea436ff98"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "051" },
                    { new Guid("f0746857-374e-4c16-bd06-21c1ee4c2346"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "007" },
                    { new Guid("f13b848d-428d-4d32-b72e-a98497c2b1e2"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "073" },
                    { new Guid("ff0bf54f-2db2-4499-b97c-56313fc221ba"), new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), true, "033" }
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "TenantName" },
                values: new object[] { new Guid("ada750ce-4167-4949-8ca8-f9f2834d40c3"), "Sumarga Farm" });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagNumber_FarmId",
                table: "Tag",
                columns: new[] { "TagNumber", "FarmId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "Goat");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
