using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Data;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Data.Repositories;
using DiunsaSCM.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.API.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using DiunsaSCM.Core.Models;
using Hangfire;
using System;
using DiunsaSCM.Core.Providers;
using DiunsaSCMInterfaceERP.Core.Entities.ERPEntities;
using DiunsaSCM.Data.Repositories.ERPRespositories;

namespace DiunsaSCM.API
{
    public class Startup
    {
        public const string SECRET = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE  IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DSCMDatabaseHangFire")));
            //services.AddHangfireServer();

            services.AddDbContext<DiunsaSCMContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DSCMDatabase")));
            //services.AddDbContext<DiunsaSCMERPContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DSCM_ERPDataBase")));

            var key = Encoding.ASCII.GetBytes(SECRET);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);

                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc();

            services.AddControllers();
            services.AddDbContext<DiunsaSCMContext>();
            //services.AddDbContext<DiunsaSCMERPContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepositoryBase<PurchOrderHeader>, PurchOrderHeaderRepository>();
            services.AddScoped<IServiceBase<PurchOrderHeaderDTO>, PurchOrderHeaderService>();
            services.AddScoped<IRepositoryBase<PurchOrderDetail>, PurchOrderDetailRepository>();
            services.AddScoped<IServiceBase<PurchOrderDetailDTO>, PurchOrderDetailService>();
            services.AddScoped<IRepository<PurchOrderShipmentDetail>, PurchOrderShipmentDetailRepository>();
            services.AddScoped<IRepository<PurchOrderShipmentHeader>, PurchOrderShipmentHeaderRepository>();
            //services.AddScoped<IRepository<InventItem>, InventItemRepository>();

            services.AddScoped<IRepositoryBase<ItemBarcode>, ItemBarcodeRepository>();
            services.AddScoped<IServiceBase<ItemBarcodeDTO>, ItemBarcodeService>();

            services.AddScoped<IPurchOrderHeaderService, PurchOrderHeaderService>();
            services.AddScoped<IPurchOrderDetailService, PurchOrderDetailService>();
            services.AddScoped<IPurchOrderShipmentDetailService, PurchOrderShipmentDetailService>();
            services.AddScoped<IPurchOrderShipmentHeaderService, PurchOrderShipmentHeaderService>();
            services.AddScoped<IShipmentContainerService, ShipmentContainerService>();
            services.AddScoped<IShippingCompanyService, ShippingCompanyService>();
            services.AddScoped<IShipmentContainerTypeService, ShipmentContainerTypeService>();
            services.AddScoped<IPortService, PortService>();
            services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IShipmentLogEntryService, ShipmentLogEntryService>();
            services.AddScoped<IShippingRouteService, ShippingRouteService>();
            services.AddScoped<IShippingRouteStepService, ShippingRouteStepService>();
            services.AddScoped<IShippingStepTypeService, ShippingStepTypeService>();
            services.AddScoped<IShippingRouteTimelineEntryService, ShippingRouteTimelineEntryService>();
            services.AddScoped<IPurchOrderShipmentRouteStepSuscriptionService, PurchOrderShipmentRouteStepSuscriptionService>();

            services.AddScoped<IRepositoryBase<ShipmentImport>, ShipmentImportRepository>();
            services.AddScoped<IServiceBase<ShipmentImportDTO>, ShipmentImportService>();
            services.AddScoped<IRepositoryBase<MarkupTrans>, MarkupTransRepository>();
            services.AddScoped<IServiceBase<MarkupTransDTO>, MarkupTransService>();


            services.AddScoped<IRepositoryBase<SKUAnalysis>, SKUAnalysisRepository>();
            services.AddScoped<IServiceBase<SKUAnalysisDTO>, SKUAnalysisService>();

            services.AddScoped<IRepositoryBase<Incoterm>, IncotermRepository>();
            services.AddScoped<IServiceBase<IncotermDTO>, IncotermService>();

            services.AddScoped<IRepositoryBase<InventItem>, InventItemRepository>();
            services.AddScoped<IServiceBase<InventItemDTO>, InventItemService>();
            services.AddScoped<IRepositoryBase<Size>, SizeRepository>();
            services.AddScoped<IServiceBase<SizeDTO>, SizeService>();
            services.AddScoped<IRepositoryBase<Color>, ColorRepository>();
            services.AddScoped<IServiceBase<ColorDTO>, ColorService>();
            services.AddScoped<IRepositoryBase<InventDim>, InventDimRepository>();
            services.AddScoped<IServiceBase<InventDimDTO>, InventDimService>();
            services.AddScoped<IRepositoryBase<Brand>, BrandRepository>();
            services.AddScoped<IServiceBase<BrandDTO>, BrandService>();
            services.AddScoped<IRepositoryBase<Unit>, UnitRepository>();
            services.AddScoped<IServiceBase<UnitDTO>, UnitService>();
            services.AddScoped<IRepositoryBase<UnitConvert>, UnitConvertRepository>();
            services.AddScoped<IServiceBase<UnitConvertDTO>, UnitConvertService>();
            services.AddScoped<IRepositoryBase<Store>, StoreRepository>();
            services.AddScoped<IServiceBase<StoreDTO>, StoreService>();
            services.AddScoped<IRepositoryBase<InventItemGroup>, InventItemGroupRepository>();
            services.AddScoped<IServiceBase<InventItemGroupDTO>, InventItemGroupService>();
            services.AddScoped<IRepositoryBase<InventDimGroup>, InventDimGroupRepository>();
            services.AddScoped<IServiceBase<InventDimGroupDTO>, InventDimGroupService>();
            services.AddScoped<IRepositoryBase<TaxOnItem>, TaxOnItemRepository>();
            services.AddScoped<IServiceBase<TaxOnItemDTO>, TaxOnItemService>();
            services.AddScoped<IRepositoryBase<TaxItemGroupHeading>, TaxItemGroupHeadingRepository>();
            services.AddScoped<IServiceBase<TaxItemGroupHeadingDTO>, TaxItemGroupHeadingService>();

            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationApproval>, PurchQuotationApprovalRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationApprovalDTO>, DiunsaSCM.Service.PurchQuotationApprovalService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotation>, PurchQuotationRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationDTO>, DiunsaSCM.Service.PurchQuotationService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationLine>, PurchQuotationLineRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationLineDTO>, DiunsaSCM.Service.PurchQuotationLineService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationApprovalRule>, PurchQuotationApprovalRuleRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationApprovalRuleDTO>, DiunsaSCM.Service.PurchQuotationApprovalRuleService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationApprovalRuleCondition>, PurchQuotationApprovalRuleConditionRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationApprovalRuleConditionDTO>, DiunsaSCM.Service.PurchQuotationApprovalRuleConditionService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationApprovalRuleConditionTerm>, PurchQuotationApprovalRuleConditionTermRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationApprovalRuleConditionTermDTO>, DiunsaSCM.Service.PurchQuotationApprovalRuleConditionTermService>();
            //services.AddScoped<IRepositoryBase<DiunsaSCM.Core.Entities.PurchQuotationApprovalLog>, PurchQuotationApprovalLogRepository>();
            //services.AddScoped<IServiceBase<DiunsaSCM.Core.Models.PurchQuotationApprovalLogDTO>, DiunsaSCM.Service.PurchQuotationApprovalLogService>();

            services.AddScoped<IRepositoryBase<PurchOrderShipmentRouteStepSuscription>, PurchOrderShipmentRouteStepSuscriptionRepository>();
            services.AddScoped<IServiceBase<PurchOrderShipmentRouteStepSuscriptionDTO>, PurchOrderShipmentRouteStepSuscriptionService>();
            services.AddScoped<IRepositoryBase<ShippingRouteStatusPresentationSchema>, ShippingRouteStatusPresentationSchemaRepository>();
            services.AddScoped<IServiceBase<ShippingRouteStatusPresentationSchemaDTO>, ShippingRouteStatusPresentationSchemaService>();

            services.AddScoped<IRepositoryBase<UserSetting>, UserSettingRepository>();
            services.AddScoped<IServiceBase<UserSettingDTO>, UserSettingService>();
            services.AddScoped<IRepositoryBase<ShipmentType>, ShipmentTypeRepository>();
            services.AddScoped<IServiceBase<ShipmentTypeDTO>, ShipmentTypeService>();
            services.AddScoped<IRepositoryBase<CommercialEvent>, CommercialEventRepository>();
            services.AddScoped<IServiceBase<CommercialEventDTO>, CommercialEventService>();

            services.AddScoped<IRepositoryBase<Vendor>, VendorRepository>();
            services.AddScoped<IServiceBase<VendorDTO>, VendorService>();
            services.AddScoped<IRepositoryBase<EmployeeDiscount>, EmployeeDiscountRepository>();
            services.AddScoped<IServiceBase<EmployeeDiscountDTO>, EmployeeDiscountService>();
            services.AddScoped<IRepositoryBase<ItemHierarchy>, ItemHierarchyRepository>();
            services.AddScoped<IServiceBase<ItemHierarchyDTO>, ItemHierarchyService>();
            services.AddScoped<IRepositoryBase<InventModelGroup>, InventModelGroupRepository>();
            services.AddScoped<IServiceBase<InventModelGroupDTO>, InventModelGroupService>();
            services.AddScoped<IRepositoryBase<InventItemStoreConfiguration>, InventItemStoreConfigurationRepository>();
            services.AddScoped<IServiceBase<InventItemStoreConfigurationDTO>, InventItemStoreConfigurationService>();

            services.AddScoped<IRepositoryBase<SalesPrice>, SalesPriceRepository>();
            services.AddScoped<IServiceBase<SalesPriceDTO>, SalesPriceService>();
            services.AddScoped<IRepositoryBase<CustomerPriceGroup>, CustomerPriceGroupRepository>();
            services.AddScoped<IServiceBase<CustomerPriceGroupDTO>, CustomerPriceGroupService>();
            services.AddScoped<IRepositoryBase<Barcode>, BarcodeRepository>();
            services.AddScoped<IServiceBase<BarcodeDTO>, BarcodeService>();
            //services.AddScoped<IRepositoryBase<BarcodeBatch>, BarcodeBatchRepository>();
            //services.AddScoped<IServiceBase<BarcodeBatchDTO>, BarcodeBatchService>();
            services.AddScoped<IRepositoryBase<BarcodeSource>, BarcodeSourceRepository>();
            services.AddScoped<IServiceBase<BarcodeSourceDTO>, BarcodeSourceService>();
            services.AddScoped<IRepositoryBase<SalesPriceDefinition>, SalesPriceDefinitionRepository>();
            services.AddScoped<IServiceBase<SalesPriceDefinitionDTO>, SalesPriceDefinitionService>();
            services.AddScoped<IRepositoryBase<SalesPriceDefinitionLine>, SalesPriceDefinitionLineRepository>();
            services.AddScoped<IServiceBase<SalesPriceDefinitionLineDTO>, SalesPriceDefinitionLineService>();

            services.AddScoped<IRepositoryBase<PurchPaymentCondition>, PurchPaymentConditionRepository>();
            services.AddScoped<IServiceBase<PurchPaymentConditionDTO>, PurchPaymentConditionService>();
            services.AddScoped<IRepositoryBase<Currency>, CurrencyRepository>();
            services.AddScoped<IServiceBase<CurrencyDTO>, CurrencyService>();

            services.AddScoped<IRepositoryBase<ItemSeasonalCategory>, ItemSeasonalCategoryRepository>();
            services.AddScoped<IServiceBase<ItemSeasonalCategoryDTO>, ItemSeasonalCategoryService>();
            services.AddScoped<IRepositoryBase<Warehouse>, WarehouseRepository>();
            services.AddScoped<IServiceBase<WarehouseDTO>, WarehouseService>();

            services.AddScoped<IImportInventTableHeaderService, ImportInventTableHeaderService>();

            services.AddScoped<IRepositoryBase<PurchCostDefinition>, PurchCostDefinitionRepository>();
            services.AddScoped<IServiceBase<PurchCostDefinitionDTO>, PurchCostDefinitionService>();
            services.AddScoped<IRepositoryBase<PurchCostDefinitionLine>, PurchCostDefinitionLineRepository>();
            services.AddScoped<IServiceBase<PurchCostDefinitionLineDTO>, PurchCostDefinitionLineService>();

            services.AddScoped<IRepositoryBase<PurchRole>, PurchRoleRepository>();
            services.AddScoped<IServiceBase<PurchRoleDTO>, PurchRoleService>();
            services.AddScoped<IRepositoryBase<PurchCommercialDepartment>, PurchCommercialDepartmentRepository>();
            services.AddScoped<IServiceBase<PurchCommercialDepartmentDTO>, PurchCommercialDepartmentService>();
            services.AddScoped<IRepositoryBase<PurchQuotationApprovalRole>, PurchQuotationApprovalRoleRepository>();
            services.AddScoped<IServiceBase<PurchQuotationApprovalRoleDTO>, PurchQuotationApprovalRoleService>();
            services.AddScoped<IRepositoryBase<PurchQuotationApprovalRuleConditionStep>, PurchQuotationApprovalRuleConditionStepRepository>();
            services.AddScoped<IServiceBase<PurchQuotationApprovalRuleConditionStepDTO>, PurchQuotationApprovalRuleConditionStepService>();

            services.AddScoped<IRepositoryBase<PurchOrderShipmentCrossDocking>, PurchOrderShipmentCrossDockingRepository>();
            services.AddScoped<IServiceBase<PurchOrderShipmentCrossDockingDTO>, PurchOrderShipmentCrossDockingService>();
            services.AddScoped<IRepositoryBase<InventItemPrepackBarcode>, InventItemPrepackBarcodeRepository>();
            services.AddScoped<IServiceBase<InventItemPrepackBarcodeDTO>, InventItemPrepackBarcodeService>();

            services.AddScoped<IRepositoryBase<PurchQuotationLinePrepackDetail>, PurchQuotationLinePrepackDetailRepository>();
            services.AddScoped<IServiceBase<PurchQuotationLinePrepackDetailDTO>, PurchQuotationLinePrepackDetailService>();

            services.AddScoped<IRepositoryBase<CommercialAgreement>, CommercialAgreementRepository>();
            services.AddScoped<IServiceBase<CommercialAgreementDTO>, CommercialAgreementService>();
            services.AddScoped<IRepositoryBase<VendorItemHierarchy>, VendorItemHierarchyRepository>();
            services.AddScoped<IServiceBase<VendorItemHierarchyDTO>, VendorItemHierarchyService>();
            services.AddScoped<IRepositoryBase<PurchRoleItemHierarchy>, PurchRoleItemHierarchyRepository>();
            services.AddScoped<IServiceBase<PurchRoleItemHierarchyDTO>, PurchRoleItemHierarchyService>();
            services.AddScoped<IRepositoryBase<PurchQuotationCreator>, PurchQuotationCreatorRepository>();
            services.AddScoped<IServiceBase<PurchQuotationCreatorDTO>, PurchQuotationCreatorService>();
            services.AddScoped<IRepositoryBase<PurchQuotationCreatorRole>, PurchQuotationCreatorRoleRepository>();
            services.AddScoped<IServiceBase<PurchQuotationCreatorRoleDTO>, PurchQuotationCreatorRoleService>();
            services.AddScoped<IRepositoryBase<InventItemPurchPriceLog>, InventItemPurchPriceLogRepository>();
            services.AddScoped<IServiceBase<InventItemPurchPriceLogDTO>, InventItemPurchPriceLogService>();
            services.AddScoped<IRepositoryBase<InventItemEnrolment>, InventItemEnrolmentRepository>();
            services.AddScoped<IServiceBase<InventItemEnrolmentDTO>, InventItemEnrolmentService>();
            services.AddScoped<IRepositoryBase<InventItemEnrolmentDetail>, InventItemEnrolmentDetailRepository>();
            services.AddScoped<IServiceBase<InventItemEnrolmentDetailDTO>, InventItemEnrolmentDetailService>();

            services.AddScoped<IPurchApprovalWorkService, PurchApprovalWorkService>();

            services.AddScoped<DiunsaSCM.Core.Repositories.ERPRepositories.IERPRepository<ERPReceiptDetail>, ERPReceiptDetailRepository>();

            //services.AddScoped<IEmailService, EmailService>();

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IWorkerService, WorkerService>();

            services.AddSingleton<SessionProvider>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, IWebHostEnvironment env, IWorkerService workerService)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");
            //            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();


            app.UseAuthorization();

            app.UseMiddleware<SessionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHangfireDashboard();
            });

            //app.UseHangfireDashboard();
            //backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            //workerService.ScheduleJobs();
        }
    }
}
