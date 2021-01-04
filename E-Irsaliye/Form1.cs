using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;


namespace E_Irsaliye
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void IrsaliyeOlustur(Irsaliye irsaliyeBilgileri, IrsaliyeHareket irsaliyeHareket)
        {
            DespatchLineType[] IrsaliyeHareketleri()
            {
                var lines = new List<DespatchLineType>();
                var line = new DespatchLineType
                {
                    ID = new IDType { Value = "1" },
                    DeliveredQuantity = new DeliveredQuantityType { unitCode = "C62", Value = 20 },
                    OrderLineReference = new OrderLineReferenceType { LineID = new LineIDType { Value = Guid.NewGuid().ToString() } },
                    Note = new[] { new NoteType { Value = "Stok-0001" + " - " + "Masa Üstü Bilgisayar" } },
                    Item = new ItemType
                    {
                        Name = new NameType1 { Value = "Masa Üstü Bilgisayar" },
                        SellersItemIdentification = new ItemIdentificationType { ID = new IDType { Value = "149159" } }
                    },
                    Shipment = new[]{new ShipmentType
                    {
                        ID=new IDType { },
                        GoodsItem=new[]{new GoodsItemType
                        {
                            /*ID=new IDType{},
                            ValueAmount=new ValueAmountType { currencyID="TRY",Value=(decimal)20000},*/
                            InvoiceLine =new[]{new InvoiceLineType
                            {
                                ID=new IDType{},
                                InvoicedQuantity=new InvoicedQuantityType{Value=(decimal)0},
                                LineExtensionAmount=new LineExtensionAmountType{currencyID="TRY", Value=20000},
                                Item=new ItemType{Name=new NameType1{}},
                                Price=new PriceType{PriceAmount=new PriceAmountType{currencyID="TRY", Value=(decimal)1000,}}
                            }
                            },
                        }
                        }
                    }
                    }
                };
                lines.Add(line);
                return lines.ToArray();
            }
            var despatchAdviceType = new DespatchAdviceType
            {
                UBLExtensions = new[] { new UBLExtensionType()},
                UBLVersionID = new UBLVersionIDType { Value = "2.1" },
                CustomizationID = new CustomizationIDType { Value = "TR1.2" },
                ProfileID = new ProfileIDType { Value = "TEMELIRSALIYE" },
                ID = new IDType { Value = irsaliyeBilgileri.IrsaliyeNo },
                CopyIndicator = new CopyIndicatorType { Value = false },
                UUID = new UUIDType { Value = Guid.NewGuid().ToString() },
                IssueDate = new IssueDateType { Value = irsaliyeBilgileri.Tarih },
                IssueTime = new IssueTimeType { Value = irsaliyeBilgileri.Tarih },
                DespatchAdviceTypeCode = new DespatchAdviceTypeCodeType { Value = "SEVK" },
                Note = new[] { new NoteType { Value = "İş bu sevk irsaliyesi muhteviyatına 7 gün içerisinde itiraz edilmediği taktirde aynen kabul edilmiş sayılır" }, },
                //LineCountNumeric = new LineCountNumericType { Value = 1 },
                OrderReference = new[] {new OrderReferenceType
                {
                    ID= new IDType { Value= Guid.NewGuid().ToString()},
                    IssueDate= new IssueDateType{Value=irsaliyeBilgileri.Tarih}
                }},
                AdditionalDocumentReference = new[]{
                        new DocumentReferenceType
                        {
                            ID =new IDType{Value = Guid.NewGuid().ToString()},
                            IssueDate = new IssueDateType{Value = irsaliyeBilgileri.Tarih},
                            DocumentTypeCode = new DocumentTypeCodeType{Value = "Katalog"},
                            DocumentType = new DocumentTypeType{Value = "Katalog Belgesi"}
                        },
                        new DocumentReferenceType
                        {
                            ID =new IDType{Value = Guid.NewGuid().ToString()},
                            IssueDate = new IssueDateType{Value = irsaliyeBilgileri.Tarih},
                            DocumentTypeCode = new DocumentTypeCodeType{Value = "Kontrat"},
                            DocumentType = new DocumentTypeType{Value = "Kontrat Belgesi"}
                        },
                },

                DespatchSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType { Value = "http://www.aaa.com.tr/" },
                        PartyIdentification = new[] { new PartyIdentificationType { ID = new IDType { schemeID = "VKN", Value = "12388331521" } } },
                        PartyName = new PartyNameType { Name = new NameType1 { Value = "AAA Anonim Şirketi" } },
                        PostalAddress = new AddressType
                        {
                            ID = new IDType { Value = "2806632739" },
                            StreetName = new StreetNameType { Value = "Selvi Caddesi Sedir Sokak" },
                            BuildingNumber = new BuildingNumberType { Value = "75/A" },
                            CityName = new CityNameType { Value = "Denizli" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "Merkezefendi" },
                            PostalZone = new PostalZoneType { Value = "06100" },
                            District = new DistrictType { Value = "Ihlamur Mahallesi" },
                            Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                        },
                        PhysicalLocation = new LocationType1
                        {
                            ID = new IDType { Value = "Depo Şube" },
                            Address = new AddressType
                            {
                                ID = new IDType { Value = "1234567895" },
                                StreetName=new StreetNameType { Value = "Ihlamur Mahallesi Selvi Caddesi Sedir Sokak" },
                                BuildingNumber=new BuildingNumberType { Value="79/A"},
                                CitySubdivisionName=new CitySubdivisionNameType { Value="Balgat"},
                                CityName=new CityNameType { Value="Ankara"},
                                PostalZone=new PostalZoneType { Value="06800"},
                                Country=new CountryType { Name=new NameType1 { Value= "Türkiye" } }
                            }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType
                        {
                            TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "Büyük Mükellefler" } }
                        },
                        Contact = new ContactType
                        {
                            Telephone = new TelephoneType { Value = "(312) 621 1111" },
                            Telefax = new TelefaxType { Value = "(312) 621 1010" },
                            ElectronicMail = new ElectronicMailType { Value = "aaa@aaa.com.tr" }
                        },
                    }
                },
                /*Signature=new[]{new SignatureType
                {
                    ID=new IDType { schemeID= "VKN_TCKN",Value= "1288331521"},
                    SignatoryParty=new PartyType
                    {
                        PartyIdentification=new[]{new PartyIdentificationType { ID = new IDType { schemeID = "VKN", Value = "1288331521" } }},
                        PostalAddress = new AddressType
                        {
                            ID = new IDType { Value = "1288331521" },
                            StreetName = new StreetNameType { Value = "Papatya Caddesi Yasemin Sokak" },
                            BuildingNumber = new BuildingNumberType { Value = "75/A" },
                            CityName = new CityNameType { Value = "Istanbul" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "Beşiktaş" },
                            PostalZone = new PostalZoneType { Value = "34100" },
                            District = new DistrictType { Value = "Ihlamur Mahallesi" },
                            Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                        },
                    },
                    DigitalSignatureAttachment=new AttachmentType
                    {
                        ExternalReference=new ExternalReferenceType{URI=new URIType{Value="#Signature"}}
                    }
                },
                },*/
                
                DeliveryCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType { Value = "http://www.BBB.com.tr/" },
                        PartyIdentification = new[] { new PartyIdentificationType { ID = new IDType { schemeID = "VKN", Value = "12388331234" } } },
                        PartyName = new PartyNameType { Name = new NameType1 { Value = "BBB Anonim Şirketi" } },
                        PostalAddress = new AddressType
                        {
                            ID = new IDType { Value = "1288331521" },
                            StreetName = new StreetNameType { Value = "Papatya Caddesi Yasemin Sokak" },
                            BuildingNumber = new BuildingNumberType { Value = "75/A" },
                            CityName = new CityNameType { Value = "Istanbul" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "Beşiktaş" },
                            PostalZone = new PostalZoneType { Value = "34100" },
                            District = new DistrictType { Value = "Ihlamur Mahallesi" },
                            Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType
                        {
                            TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "Büyük Mükellefler" } }
                        },
                        Contact = new ContactType
                        {
                            Telephone = new TelephoneType { Value = "(312) 621 7777" },
                            Telefax = new TelefaxType { Value = "(312) 621 7070" },
                            ElectronicMail = new ElectronicMailType { Value = "bb@bbb.com.tr" }
                        },
                    }
                },
                Shipment = new ShipmentType
                {
                    ID = new IDType { Value = Guid.NewGuid().ToString() },
                    GoodsItem = new[]{new GoodsItemType
                    {
                        ValueAmount=new ValueAmountType { currencyID="TRY", Value=20000},
                    } },
                    ShipmentStage = new[]{new ShipmentStageType
                    {
                        TransportMeans=new TransportMeansType
                        {
                            RoadTransport=new RoadTransportType
                            {
                                LicensePlateID=new LicensePlateIDType { schemeID="DORSEPLAKA"}
                            }
                        },
                        DriverPerson=new[]
                        {
                            new PersonType
                            {
                                FirstName=new FirstNameType{Value="Mehmet"},
                                FamilyName=new FamilyNameType { Value="Öztürk"},
                                Title=new TitleType { Value="Şoför"},
                                NationalityID=new NationalityIDType { schemeID = "TCKN", Value = "14922266699" }
                            },
                            new PersonType
                            {
                                FirstName=new FirstNameType{Value="Mustafa"},
                                FamilyName=new FamilyNameType { Value="Öztürk"},
                                Title=new TitleType { Value="Şoför"},
                                NationalityID=new NationalityIDType { schemeID = "TCKN", Value = "14922266600" }
                            }
                        },
                    },
                    },
                    Delivery = new DeliveryType
                    {
                        CarrierParty = new PartyType
                        {
                            PartyIdentification = new[] { new PartyIdentificationType { ID = new IDType { schemeID = "VKN", Value = "1288331523" } } },
                            PartyName = new PartyNameType { Name = new NameType1 { Value = "CCC Lojistik Anonim" } },
                            PostalAddress = new AddressType
                            {
                                CitySubdivisionName = new CitySubdivisionNameType { Value = "Osmancık" },
                                CityName = new CityNameType { Value = "Çorum" },
                                Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                            }
                        },
                        Despatch = new DespatchType
                        {
                            ActualDespatchDate = new ActualDespatchDateType { Value = DateTime.Now },
                            ActualDespatchTime = new ActualDespatchTimeType { Value = DateTime.Now }
                        }
                    },
                    TransportHandlingUnit = new[]{new TransportHandlingUnitType
                    {
                        TransportEquipment = new[]{new TransportEquipmentType
                        {
                            ID=new IDType {schemeID="DORSEPLAKA",Value="06DR4088"}
                        },
                        new TransportEquipmentType
                        {
                            ID=new IDType{schemeID="DORSEPLAKA",Value="06DR4099"}
                        }
                        }
                    },
                    }
                },

                DespatchLine = IrsaliyeHareketleri(),
            };
            if (irsaliyeHareket.KargoBilgileriGözüksünMü)
            {
                despatchAdviceType.Signature = new[]
                    {
                        new SignatureType
                        {
                            ID = new IDType{schemeID = "VKN_TCKN",Value = "1234567890"},
                            SignatoryParty = new PartyType
                            {
                                PartyIdentification = new []{ new PartyIdentificationType { ID = new IDType{ schemeID = "VKN", Value = "1234567890" } } },
                                PostalAddress = new AddressType
                                {
                                    Room = new RoomType{Value = "25"},
                                    BlockName = new BlockNameType{Value = "A Blok"},
                                    BuildingName = new BuildingNameType{Value = "Karanfil"},
                                    BuildingNumber = new BuildingNumberType{Value = "345"},
                                    CitySubdivisionName = new CitySubdivisionNameType{Value = "Çankaya"},
                                    CityName = new CityNameType{Value = "Ankara"},
                                    PostalZone = new PostalZoneType{Value = "06200"},
                                    Country = new CountryType{Name = new NameType1{Value = "Türkiye"}}
                                }
                            },
                            DigitalSignatureAttachment = new AttachmentType { ExternalReference = new ExternalReferenceType { URI = new URIType { Value = "#Signature_" + irsaliyeBilgileri.IrsaliyeNo } } }
                        },
                    };
            }

            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
            settings.Encoding = Encoding.GetEncoding("UTF-8");
            var ms = new MemoryStream();
            var writer = XmlWriter.Create(ms, settings);
            var srl = new XmlSerializer(despatchAdviceType.GetType());
            srl.Serialize(writer, despatchAdviceType, XmlNameSpace());
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            var srRead = new StreamReader(ms);
            var readXml = srRead.ReadToEnd();
            var path = Path.Combine($@"{Application.StartupPath}\EArsivFaturalar\{ despatchAdviceType.ID.Value }.xml");

            void EFaturaOlustur()
            {
                using (var sWriter = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sWriter.Write(readXml);
                    sWriter.Close();
                }
            }

            if (!Directory.Exists($@"{Application.StartupPath}\EArsivFaturalar"))
                Directory.CreateDirectory($@"{Application.StartupPath}\EArsivFaturalar");

            if (!File.Exists($@"{Application.StartupPath}\EArsivFaturalar\{ despatchAdviceType.ID.Value }.xml"))
                EFaturaOlustur();

            else
                if (MessageBox.Show($@"{ despatchAdviceType.ID.Value }.xml dosyasıdaha önce oluşturulmuş. Yeniden oluşturulsun mu?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                EFaturaOlustur();

            if (MessageBox.Show($@"Fatura oluşturma işlemi başarılı bir şekilde tamamlandı. Faturalar '{Application.StartupPath}\EArsivFaturalar' konumunda oluşturuldu. Konumu açmak istiyor musununz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
            Process.Start(Application.StartupPath + "\\EArsivFaturalar");

            XmlSerializerNamespaces XmlNameSpace()
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                //ns.Add("schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2 ../xsdrt/maindoc/UBL-DespatchAdvice-2.1.xsd");
                //ns.Add("urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2");
                ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                ns.Add("n4", "http://www.altova.com/samplexml/other-namespace#");
                /*ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
                ns.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                //ns.Add("ubltr", "urn:oasis:names:specification:ubl:schema:xsd:TurkishCustomizationExtensionComponents");
                //ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
                ns.Add("n4", "http://www.altova.com/samplexml/other-namespace#");*/
                return ns;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            var IrsaliyeBilgileri = new Irsaliye
            {
                CariKodu = "120 10 01 002",
                CariAdi = "Hasan Yılmaz",
                Tarih = DateTime.Now,
                IrsaliyeNo = "EAR2019000000001",
                Tutar = 660,
                Isklonto = 66,
                NetTutar = 594,
                KdvTutari = (decimal)106.92,
                ToplamTutar = (decimal)700.92
            };
            var irsaliyeHareket = new IrsaliyeHareket();
            irsaliyeHareket.KargoBilgileriGözüksünMü = chbKargoBilgileri.Checked ? true : false;
            IrsaliyeOlustur(IrsaliyeBilgileri, irsaliyeHareket);
            
            string GetDocumentText(string xmlFilePath, string xsltFilePath)
            {
                var xslTransForm = new XslCompiledTransform();
                var stringWriter = new StringWriter();
                var reader = XmlReader.Create(xsltFilePath, new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse });
                xslTransForm.Load(reader);
                xslTransForm.Transform(xmlFilePath, null, stringWriter);
                return stringWriter.ToString();
            }
            var xml = $@"{Application.StartupPath}\EArsivFaturalar\{IrsaliyeBilgileri.IrsaliyeNo}.xml";
            var xslt = $@"{Application.StartupPath}\irsaliye.xslt";

            var frm = new FormGoruntuleyici(GetDocumentText(xml, xslt));
            frm.ShowDialog();
        }
    }
}
