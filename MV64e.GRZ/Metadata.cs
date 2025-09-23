#pragma warning disable CS8765
#pragma warning disable CS8618

namespace MV64e.GRZ
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// General metadata schema for submissions to the GRZ
    /// </summary>
    public partial class Metadata
    {
        /// <summary>
        /// List of donors including the index patient.
        /// </summary>
        [JsonProperty("donors", Required = Required.Always)]
        public List<Donor> Donors { get; set; }

        [JsonProperty("submission", Required = Required.Always)]
        public Submission Submission { get; set; }
    }

    public partial class Donor
    {
        /// <summary>
        /// A unique identifier given by the Leistungserbringer for each donor of a single, duo or
        /// trio sequencing; the donorPseudonym needs to be identifiable by the Leistungserbringer in
        /// case of changes to the consents by one of the donors. For Index patient use index.
        /// </summary>
        [JsonProperty("donorPseudonym", Required = Required.Always)]
        public string DonorPseudonym { get; set; }

        /// <summary>
        /// Gender of the donor.
        /// </summary>
        [JsonProperty("gender", Required = Required.Always)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Lab data related to the donor.
        /// </summary>
        [JsonProperty("labData", Required = Required.Always)]
        public List<LabDatum> LabData { get; set; }

        [JsonProperty("mvConsent", Required = Required.Always)]
        public MvConsent MvConsent { get; set; }

        /// <summary>
        /// Relationship of the donor in respect to the index patient, e.g. 'index', 'brother',
        /// 'mother', etc.
        /// </summary>
        [JsonProperty("relation", Required = Required.Always)]
        public Relation Relation { get; set; }

        /// <summary>
        /// Research consents. Multiple declarations of consent are possible! Must be assigned to the
        /// respective data sets.
        /// </summary>
        [JsonProperty("researchConsents", Required = Required.Always)]
        public List<ResearchConsent> ResearchConsents { get; set; }
    }

    public partial class LabDatum
    {
        /// <summary>
        /// The barcode used or 'na'
        /// </summary>
        [JsonProperty("barcode", Required = Required.Always)]
        public string Barcode { get; set; }

        /// <summary>
        /// Name/version of the enrichment kit
        /// </summary>
        [JsonProperty("enrichmentKitDescription", Required = Required.Always)]
        public string EnrichmentKitDescription { get; set; }

        /// <summary>
        /// Manufacturer of the enrichment kit
        /// </summary>
        [JsonProperty("enrichmentKitManufacturer", Required = Required.Always)]
        public EnrichmentKitManufacturer EnrichmentKitManufacturer { get; set; }

        /// <summary>
        /// Fragmentation method
        /// </summary>
        [JsonProperty("fragmentationMethod", Required = Required.Always)]
        public FragmentationMethod FragmentationMethod { get; set; }

        /// <summary>
        /// Sequencing kit manufacturer
        /// </summary>
        [JsonProperty("kitManufacturer", Required = Required.Always)]
        public string KitManufacturer { get; set; }

        /// <summary>
        /// Name/version of the sequencing kit
        /// </summary>
        [JsonProperty("kitName", Required = Required.Always)]
        public string KitName { get; set; }

        /// <summary>
        /// Name/ID of the biospecimen e.g. 'Blut DNA normal'
        /// </summary>
        [JsonProperty("labDataName", Required = Required.Always)]
        public string LabDataName { get; set; }

        /// <summary>
        /// Name/version of the library prepkit
        /// </summary>
        [JsonProperty("libraryPrepKit", Required = Required.Always)]
        public string LibraryPrepKit { get; set; }

        /// <summary>
        /// Library prep kit manufacturer
        /// </summary>
        [JsonProperty("libraryPrepKitManufacturer", Required = Required.Always)]
        public string LibraryPrepKitManufacturer { get; set; }

        /// <summary>
        /// Library type
        /// </summary>
        [JsonProperty("libraryType", Required = Required.Always)]
        public LibraryType LibraryType { get; set; }

        /// <summary>
        /// Sample conservation
        /// </summary>
        [JsonProperty("sampleConservation", Required = Required.Always)]
        public SampleConservation SampleConservation { get; set; }

        /// <summary>
        /// Date of sample in ISO 8601 format YYYY-MM-DD
        /// </summary>
        [JsonProperty("sampleDate", Required = Required.Always)]
        public DateTimeOffset SampleDate { get; set; }

        /// <summary>
        /// Sequence data generated from the wet lab experiment.
        /// </summary>
        [JsonProperty("sequenceData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SequenceData SequenceData { get; set; }

        /// <summary>
        /// Subtype of sequence (germline, somatic, etc.)
        /// </summary>
        [JsonProperty("sequenceSubtype", Required = Required.Always)]
        public SequenceSubtype SequenceSubtype { get; set; }

        /// <summary>
        /// Type of sequence (DNA or RNA)
        /// </summary>
        [JsonProperty("sequenceType", Required = Required.Always)]
        public SequenceType SequenceType { get; set; }

        /// <summary>
        /// Sequencer manufacturer
        /// </summary>
        [JsonProperty("sequencerManufacturer", Required = Required.Always)]
        public string SequencerManufacturer { get; set; }

        /// <summary>
        /// Name/version of the sequencer model
        /// </summary>
        [JsonProperty("sequencerModel", Required = Required.Always)]
        public string SequencerModel { get; set; }

        /// <summary>
        /// The sequencing layout, aka the end type of sequencing.
        /// </summary>
        [JsonProperty("sequencingLayout", Required = Required.Always)]
        public SequencingLayout SequencingLayout { get; set; }

        [JsonProperty("tissueOntology", Required = Required.Always)]
        public TissueOntology TissueOntology { get; set; }

        /// <summary>
        /// Tissue ID according to the ontology in use.
        /// </summary>
        [JsonProperty("tissueTypeId", Required = Required.Always)]
        public string TissueTypeId { get; set; }

        /// <summary>
        /// Tissue name according to the ontology in use.
        /// </summary>
        [JsonProperty("tissueTypeName", Required = Required.Always)]
        public string TissueTypeName { get; set; }

        /// <summary>
        /// Tuple of tumor cell counts and how they were determined.
        /// </summary>
        [JsonProperty("tumorCellCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<TumorCellCount> TumorCellCount { get; set; }
    }

    /// <summary>
    /// Sequence data generated from the wet lab experiment.
    /// </summary>
    public partial class SequenceData
    {
        /// <summary>
        /// Name of the bioinformatics pipeline used
        /// </summary>
        [JsonProperty("bioinformaticsPipelineName", Required = Required.Always)]
        public string BioinformaticsPipelineName { get; set; }

        /// <summary>
        /// Version or commit hash of the bioinformatics pipeline
        /// </summary>
        [JsonProperty("bioinformaticsPipelineVersion", Required = Required.Always)]
        public string BioinformaticsPipelineVersion { get; set; }

        /// <summary>
        /// Caller that is used in the pipeline
        /// </summary>
        [JsonProperty("callerUsed", Required = Required.Always)]
        public List<CallerUsed> CallerUsed { get; set; }

        /// <summary>
        /// List of files generated and required in this analysis.
        /// </summary>
        [JsonProperty("files", Required = Required.Always)]
        public List<File> Files { get; set; }

        /// <summary>
        /// Mean depth of coverage
        /// </summary>
        [JsonProperty("meanDepthOfCoverage", Required = Required.Always)]
        [JsonConverter(typeof(PurpleMinMaxValueCheckConverter))]
        public double MeanDepthOfCoverage { get; set; }

        /// <summary>
        /// Minimum coverage
        /// </summary>
        [JsonProperty("minCoverage", Required = Required.Always)]
        [JsonConverter(typeof(PurpleMinMaxValueCheckConverter))]
        public double MinCoverage { get; set; }

        /// <summary>
        /// The analysis includes non-coding variants -> true or false
        /// </summary>
        [JsonProperty("nonCodingVariants", Required = Required.Always)]
        public bool NonCodingVariants { get; set; }

        /// <summary>
        /// Percentage of bases with a specified minimum quality threshold, according to
        /// https://www.bfarm.de/SharedDocs/Downloads/DE/Forschung/modellvorhaben-genomsequenzierung/Qs-durch-GRZ.pdf?__blob=publicationFile
        /// </summary>
        [JsonProperty("percentBasesAboveQualityThreshold", Required = Required.Always)]
        public PercentBasesAboveQualityThreshold PercentBasesAboveQualityThreshold { get; set; }

        /// <summary>
        /// Reference genome used according to the Genome Reference Consortium
        /// (https://www.ncbi.nlm.nih.gov/grc)
        /// </summary>
        [JsonProperty("referenceGenome", Required = Required.Always)]
        public ReferenceGenome ReferenceGenome { get; set; }

        /// <summary>
        /// Fraction of targeted regions that are above minimum coverage
        /// </summary>
        [JsonProperty("targetedRegionsAboveMinCoverage", Required = Required.Always)]
        [JsonConverter(typeof(TentacledMinMaxValueCheckConverter))]
        public double TargetedRegionsAboveMinCoverage { get; set; }
    }

    public partial class CallerUsed
    {
        /// <summary>
        /// Name of the caller used
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Version of the caller used
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }

    public partial class File
    {
        /// <summary>
        /// Type of checksum algorithm used
        /// </summary>
        [JsonProperty("checksumType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ChecksumType? ChecksumType { get; set; }

        /// <summary>
        /// checksum of the file
        /// </summary>
        [JsonProperty("fileChecksum", Required = Required.Always)]
        public string FileChecksum { get; set; }

        /// <summary>
        /// Path relative to the submission files directory, e.g.:
        /// 'patient_001/patient_001_dna.fastq.gz' if the file is located in <submission
        /// root>/files/patient_001/patient_001_dna.fastq.gz
        /// </summary>
        [JsonProperty("filePath", Required = Required.Always)]
        public string FilePath { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [JsonProperty("fileSizeInBytes", Required = Required.Always)]
        [JsonConverter(typeof(PurpleMinMaxValueCheckConverter))]
        public double FileSizeInBytes { get; set; }

        /// <summary>
        /// Type of the file; if BED file is submitted, only 1 file is allowed.
        /// </summary>
        [JsonProperty("fileType", Required = Required.Always)]
        public FileType FileType { get; set; }

        /// <summary>
        /// Indicates the flow cell.
        /// </summary>
        [JsonProperty("flowcellId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FlowcellId { get; set; }

        /// <summary>
        /// Indicates the lane
        /// </summary>
        [JsonProperty("laneId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LaneId { get; set; }

        /// <summary>
        /// The read length; in the case of long-read sequencing it is the rounded average read
        /// length.
        /// </summary>
        [JsonProperty("readLength", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? ReadLength { get; set; }

        /// <summary>
        /// Indicates the read order for paired-end reads.
        /// </summary>
        [JsonProperty("readOrder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ReadOrder? ReadOrder { get; set; }
    }

    /// <summary>
    /// Percentage of bases with a specified minimum quality threshold, according to
    /// https://www.bfarm.de/SharedDocs/Downloads/DE/Forschung/modellvorhaben-genomsequenzierung/Qs-durch-GRZ.pdf?__blob=publicationFile
    /// </summary>
    public partial class PercentBasesAboveQualityThreshold
    {
        /// <summary>
        /// The minimum quality score threshold
        /// </summary>
        [JsonProperty("minimumQuality", Required = Required.Always)]
        [JsonConverter(typeof(PurpleMinMaxValueCheckConverter))]
        public double MinimumQuality { get; set; }

        /// <summary>
        /// Percentage of bases that meet or exceed the minimum quality score
        /// </summary>
        [JsonProperty("percent", Required = Required.Always)]
        [JsonConverter(typeof(FluffyMinMaxValueCheckConverter))]
        public double Percent { get; set; }
    }

    public partial class TissueOntology
    {
        /// <summary>
        /// Name of the tissue ontology
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Version of the tissue ontology
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }

    public partial class TumorCellCount
    {
        /// <summary>
        /// Tumor cell count in %
        /// </summary>
        [JsonProperty("count", Required = Required.Always)]
        [JsonConverter(typeof(FluffyMinMaxValueCheckConverter))]
        public double Count { get; set; }

        /// <summary>
        /// Method used to determine cell count.
        /// </summary>
        [JsonProperty("method", Required = Required.Always)]
        public Method Method { get; set; }
    }

    public partial class MvConsent
    {
        /// <summary>
        /// Date of delivery. Date (in ISO 8601 format YYYY-MM-DD) on which the Model Project
        /// Declaration of Participation was presented to the patient, unless identical to the date
        /// of signature
        /// </summary>
        [JsonProperty("presentationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PresentationDate { get; set; }

        /// <summary>
        /// Modules of the consent to MV: must have at least a permit of mvSequencing
        /// </summary>
        [JsonProperty("scope", Required = Required.Always)]
        public List<Scope> Scope { get; set; }

        /// <summary>
        /// Version of the declaration of participation. Name and version of the declaration of
        /// participation in the MV GenomSeq, e.g.: 'Patient Info TE Consent MVGenomSeq vers01'
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }

    public partial class Scope
    {
        /// <summary>
        /// Date of signature of the pilot projects consent; in ISO 8601 format YYYY-MM-DD.
        /// </summary>
        [JsonProperty("date", Required = Required.Always)]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Scope of consent or revocation.
        /// </summary>
        [JsonProperty("domain", Required = Required.Always)]
        public Domain Domain { get; set; }

        /// <summary>
        /// Consent or refusal to participate and consent, must be indicated for each option listed
        /// in the scope of consent.
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public TypeEnum Type { get; set; }
    }

    public partial class ResearchConsent
    {
        /// <summary>
        /// Justification if no scope object is present.
        /// </summary>
        [JsonProperty("noScopeJustification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public NoScopeJustification? NoScopeJustification { get; set; }

        /// <summary>
        /// Date of the delivery of the research consent in ISO 8601 format (YYYY-MM-DD)
        /// </summary>
        [JsonProperty("presentationDate", Required = Required.Always)]
        public DateTimeOffset PresentationDate { get; set; }

        /// <summary>
        /// Schema version of de.medizininformatikinitiative.kerndatensatz.consent
        /// </summary>
        [JsonProperty("schemaVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SchemaVersion? SchemaVersion { get; set; }

        /// <summary>
        /// Scope of the research consent in JSON format following the MII IG Consent v2025 FHIR
        /// schema. See
        /// 'https://www.medizininformatik-initiative.de/Kerndatensatz/KDS_Consent_V2025/MII-IG-Modul-Consent.html'
        /// and
        /// 'https://packages2.fhir.org/packages/de.medizininformatikinitiative.kerndatensatz.consent'.
        /// </summary>
        [JsonProperty("scope", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Scope { get; set; }
    }

    public partial class Submission
    {
        /// <summary>
        /// ID of the clinical data node in the format KDKXXXnnn.
        /// </summary>
        [JsonProperty("clinicalDataNodeId", Required = Required.Always)]
        public string ClinicalDataNodeId { get; set; }

        /// <summary>
        /// "GKV" gesetzliche Krankenversicherung, "PKV" private Krankenversicherung, "BG"
        /// Berufsgenossenschaft, "SEL" Selbstzahler, "SOZ" Sozialamt, "GPV" gesetzliche
        /// Pflegeversicherung, "PPV" private Pflegeversicherung, "BEI" Beihilfe, "SKT" Sonstige
        /// Kostenträger, "UNK" Unbekannt
        /// </summary>
        [JsonProperty("coverageType", Required = Required.Always)]
        public CoverageType CoverageType { get; set; }

        /// <summary>
        /// Type of the disease
        /// </summary>
        [JsonProperty("diseaseType", Required = Required.Always)]
        public DiseaseType DiseaseType { get; set; }

        /// <summary>
        /// ID of the genomic data center in the format GRZXXXnnn.
        /// </summary>
        [JsonProperty("genomicDataCenterId", Required = Required.Always)]
        public string GenomicDataCenterId { get; set; }

        /// <summary>
        /// whether tumor and/or germ-line are tested
        /// </summary>
        [JsonProperty("genomicStudySubtype", Required = Required.Always)]
        public GenomicStudySubtype GenomicStudySubtype { get; set; }

        /// <summary>
        /// whether additional persons are tested as well
        /// </summary>
        [JsonProperty("genomicStudyType", Required = Required.Always)]
        public GenomicStudyType GenomicStudyType { get; set; }

        /// <summary>
        /// Name of the sequencing lab.
        /// </summary>
        [JsonProperty("labName", Required = Required.Always)]
        public string LabName { get; set; }

        /// <summary>
        /// A local case identifier of the Leistungserbringer to be able to track multiple
        /// submissions referring to the same index patient
        /// </summary>
        [JsonProperty("localCaseId", Required = Required.Always)]
        public string LocalCaseId { get; set; }

        /// <summary>
        /// Date of submission in ISO 8601 format YYYY-MM-DD
        /// </summary>
        [JsonProperty("submissionDate", Required = Required.Always)]
        public DateTimeOffset SubmissionDate { get; set; }

        /// <summary>
        /// The options are: 'initial' for first submission, 'followup' is for followup submissions,
        /// 'addition' for additional submission, 'correction' for correction
        /// </summary>
        [JsonProperty("submissionType", Required = Required.Always)]
        public SubmissionType SubmissionType { get; set; }

        /// <summary>
        /// Institutional ID of the submitter according to §293 SGB V.
        /// </summary>
        [JsonProperty("submitterId", Required = Required.Always)]
        public string SubmitterId { get; set; }

        /// <summary>
        /// The VNg of the genomic data of the index patient that will be reimbursed --> a unique
        /// 32-length byte code represented in a hex string of length 64.
        /// </summary>
        [JsonProperty("tanG", Required = Required.Always)]
        public string TanG { get; set; }
    }

    /// <summary>
    /// Gender of the donor.
    /// </summary>
    public enum Gender { Female, Male, Other, Unknown };

    /// <summary>
    /// Manufacturer of the enrichment kit
    /// </summary>
    public enum EnrichmentKitManufacturer { Agilent, Illumina, Neb, None, Other, Twist, Unknown };

    /// <summary>
    /// Fragmentation method
    /// </summary>
    public enum FragmentationMethod { Enzymatic, None, Other, Sonication, Unknown };

    /// <summary>
    /// Library type
    /// </summary>
    public enum LibraryType { Other, Panel, PanelLr, Unknown, Wes, WesLr, Wgs, WgsLr, Wxs, WxsLr };

    /// <summary>
    /// Sample conservation
    /// </summary>
    public enum SampleConservation { CryoFrozen, Ffpe, FreshTissue, Other, Unknown };

    /// <summary>
    /// Type of checksum algorithm used
    /// </summary>
    public enum ChecksumType { Sha256 };

    /// <summary>
    /// Type of the file; if BED file is submitted, only 1 file is allowed.
    /// </summary>
    public enum FileType { Bam, Bed, Fastq, Vcf };

    /// <summary>
    /// Indicates the read order for paired-end reads.
    /// </summary>
    public enum ReadOrder { R1, R2 };

    /// <summary>
    /// Reference genome used according to the Genome Reference Consortium
    /// (https://www.ncbi.nlm.nih.gov/grc)
    /// </summary>
    public enum ReferenceGenome { GrCh37, GrCh38 };

    /// <summary>
    /// Subtype of sequence (germline, somatic, etc.)
    /// </summary>
    public enum SequenceSubtype { Germline, Other, Somatic, Unknown };

    /// <summary>
    /// Type of sequence (DNA or RNA)
    /// </summary>
    public enum SequenceType { Dna, Rna };

    /// <summary>
    /// The sequencing layout, aka the end type of sequencing.
    /// </summary>
    public enum SequencingLayout { Other, PairedEnd, Reverse, SingleEnd };

    /// <summary>
    /// Method used to determine cell count.
    /// </summary>
    public enum Method { Bioinformatics, Other, Pathology, Unknown };

    /// <summary>
    /// Scope of consent or revocation.
    /// </summary>
    public enum Domain { CaseIdentification, MvSequencing, ReIdentification };

    /// <summary>
    /// Consent or refusal to participate and consent, must be indicated for each option listed
    /// in the scope of consent.
    /// </summary>
    public enum TypeEnum { Deny, Permit };

    /// <summary>
    /// Relationship of the donor in respect to the index patient, e.g. 'index', 'brother',
    /// 'mother', etc.
    /// </summary>
    public enum Relation { Brother, Child, Father, Index, Mother, Other, Sister };

    /// <summary>
    /// Justification if no scope object is present.
    /// </summary>
    public enum NoScopeJustification { TechnicalReason, OrganizationalIssues, OtherPatientRelatedReason, PatientDidNotReturnConsentDocuments, PatientRefusesToSignConsent, PatientUnableToConsent };

    /// <summary>
    /// Schema version of de.medizininformatikinitiative.kerndatensatz.consent
    /// </summary>
    public enum SchemaVersion { The202501 };

    /// <summary>
    /// "GKV" gesetzliche Krankenversicherung, "PKV" private Krankenversicherung, "BG"
    /// Berufsgenossenschaft, "SEL" Selbstzahler, "SOZ" Sozialamt, "GPV" gesetzliche
    /// Pflegeversicherung, "PPV" private Pflegeversicherung, "BEI" Beihilfe, "SKT" Sonstige
    /// Kostenträger, "UNK" Unbekannt
    /// </summary>
    public enum CoverageType { Bei, Bg, Gkv, Gpv, Pkv, Ppv, Sel, Skt, Soz, Unk };

    /// <summary>
    /// Type of the disease
    /// </summary>
    public enum DiseaseType { Hereditary, Oncological, Rare };

    /// <summary>
    /// whether tumor and/or germ-line are tested
    /// </summary>
    public enum GenomicStudySubtype { GermlineOnly, TumorGermline, TumorOnly };

    /// <summary>
    /// whether additional persons are tested as well
    /// </summary>
    public enum GenomicStudyType { Duo, Single, Trio };

    /// <summary>
    /// The options are: 'initial' for first submission, 'followup' is for followup submissions,
    /// 'addition' for additional submission, 'correction' for correction
    /// </summary>
    public enum SubmissionType { Addition, Correction, Followup, Initial, Test };

    public partial class Metadata
    {
        public static Metadata FromJson(string json) => JsonConvert.DeserializeObject<Metadata>(json, MV64e.GRZ.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Metadata self) => JsonConvert.SerializeObject(self, MV64e.GRZ.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            MissingMemberHandling = MissingMemberHandling.Error,
            Converters =
            {
                GenderConverter.Singleton,
                EnrichmentKitManufacturerConverter.Singleton,
                FragmentationMethodConverter.Singleton,
                LibraryTypeConverter.Singleton,
                SampleConservationConverter.Singleton,
                ChecksumTypeConverter.Singleton,
                FileTypeConverter.Singleton,
                ReadOrderConverter.Singleton,
                ReferenceGenomeConverter.Singleton,
                SequenceSubtypeConverter.Singleton,
                SequenceTypeConverter.Singleton,
                SequencingLayoutConverter.Singleton,
                MethodConverter.Singleton,
                DomainConverter.Singleton,
                TypeEnumConverter.Singleton,
                RelationConverter.Singleton,
                NoScopeJustificationConverter.Singleton,
                SchemaVersionConverter.Singleton,
                CoverageTypeConverter.Singleton,
                DiseaseTypeConverter.Singleton,
                GenomicStudySubtypeConverter.Singleton,
                GenomicStudyTypeConverter.Singleton,
                SubmissionTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gender) || t == typeof(Gender?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "female":
                    return Gender.Female;
                case "male":
                    return Gender.Male;
                case "other":
                    return Gender.Other;
                case "unknown":
                    return Gender.Unknown;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gender)untypedValue;
            switch (value)
            {
                case Gender.Female:
                    serializer.Serialize(writer, "female");
                    return;
                case Gender.Male:
                    serializer.Serialize(writer, "male");
                    return;
                case Gender.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case Gender.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

    internal class EnrichmentKitManufacturerConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EnrichmentKitManufacturer) || t == typeof(EnrichmentKitManufacturer?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Agilent":
                    return EnrichmentKitManufacturer.Agilent;
                case "Illumina":
                    return EnrichmentKitManufacturer.Illumina;
                case "NEB":
                    return EnrichmentKitManufacturer.Neb;
                case "Twist":
                    return EnrichmentKitManufacturer.Twist;
                case "none":
                    return EnrichmentKitManufacturer.None;
                case "other":
                    return EnrichmentKitManufacturer.Other;
                case "unknown":
                    return EnrichmentKitManufacturer.Unknown;
            }
            throw new Exception("Cannot unmarshal type EnrichmentKitManufacturer");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EnrichmentKitManufacturer)untypedValue;
            switch (value)
            {
                case EnrichmentKitManufacturer.Agilent:
                    serializer.Serialize(writer, "Agilent");
                    return;
                case EnrichmentKitManufacturer.Illumina:
                    serializer.Serialize(writer, "Illumina");
                    return;
                case EnrichmentKitManufacturer.Neb:
                    serializer.Serialize(writer, "NEB");
                    return;
                case EnrichmentKitManufacturer.Twist:
                    serializer.Serialize(writer, "Twist");
                    return;
                case EnrichmentKitManufacturer.None:
                    serializer.Serialize(writer, "none");
                    return;
                case EnrichmentKitManufacturer.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case EnrichmentKitManufacturer.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type EnrichmentKitManufacturer");
        }

        public static readonly EnrichmentKitManufacturerConverter Singleton = new EnrichmentKitManufacturerConverter();
    }

    internal class FragmentationMethodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FragmentationMethod) || t == typeof(FragmentationMethod?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "enzymatic":
                    return FragmentationMethod.Enzymatic;
                case "none":
                    return FragmentationMethod.None;
                case "other":
                    return FragmentationMethod.Other;
                case "sonication":
                    return FragmentationMethod.Sonication;
                case "unknown":
                    return FragmentationMethod.Unknown;
            }
            throw new Exception("Cannot unmarshal type FragmentationMethod");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FragmentationMethod)untypedValue;
            switch (value)
            {
                case FragmentationMethod.Enzymatic:
                    serializer.Serialize(writer, "enzymatic");
                    return;
                case FragmentationMethod.None:
                    serializer.Serialize(writer, "none");
                    return;
                case FragmentationMethod.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case FragmentationMethod.Sonication:
                    serializer.Serialize(writer, "sonication");
                    return;
                case FragmentationMethod.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type FragmentationMethod");
        }

        public static readonly FragmentationMethodConverter Singleton = new FragmentationMethodConverter();
    }

    internal class LibraryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LibraryType) || t == typeof(LibraryType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "other":
                    return LibraryType.Other;
                case "panel":
                    return LibraryType.Panel;
                case "panel_lr":
                    return LibraryType.PanelLr;
                case "unknown":
                    return LibraryType.Unknown;
                case "wes":
                    return LibraryType.Wes;
                case "wes_lr":
                    return LibraryType.WesLr;
                case "wgs":
                    return LibraryType.Wgs;
                case "wgs_lr":
                    return LibraryType.WgsLr;
                case "wxs":
                    return LibraryType.Wxs;
                case "wxs_lr":
                    return LibraryType.WxsLr;
            }
            throw new Exception("Cannot unmarshal type LibraryType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LibraryType)untypedValue;
            switch (value)
            {
                case LibraryType.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case LibraryType.Panel:
                    serializer.Serialize(writer, "panel");
                    return;
                case LibraryType.PanelLr:
                    serializer.Serialize(writer, "panel_lr");
                    return;
                case LibraryType.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
                case LibraryType.Wes:
                    serializer.Serialize(writer, "wes");
                    return;
                case LibraryType.WesLr:
                    serializer.Serialize(writer, "wes_lr");
                    return;
                case LibraryType.Wgs:
                    serializer.Serialize(writer, "wgs");
                    return;
                case LibraryType.WgsLr:
                    serializer.Serialize(writer, "wgs_lr");
                    return;
                case LibraryType.Wxs:
                    serializer.Serialize(writer, "wxs");
                    return;
                case LibraryType.WxsLr:
                    serializer.Serialize(writer, "wxs_lr");
                    return;
            }
            throw new Exception("Cannot marshal type LibraryType");
        }

        public static readonly LibraryTypeConverter Singleton = new LibraryTypeConverter();
    }

    internal class SampleConservationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SampleConservation) || t == typeof(SampleConservation?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cryo-frozen":
                    return SampleConservation.CryoFrozen;
                case "ffpe":
                    return SampleConservation.Ffpe;
                case "fresh-tissue":
                    return SampleConservation.FreshTissue;
                case "other":
                    return SampleConservation.Other;
                case "unknown":
                    return SampleConservation.Unknown;
            }
            throw new Exception("Cannot unmarshal type SampleConservation");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SampleConservation)untypedValue;
            switch (value)
            {
                case SampleConservation.CryoFrozen:
                    serializer.Serialize(writer, "cryo-frozen");
                    return;
                case SampleConservation.Ffpe:
                    serializer.Serialize(writer, "ffpe");
                    return;
                case SampleConservation.FreshTissue:
                    serializer.Serialize(writer, "fresh-tissue");
                    return;
                case SampleConservation.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case SampleConservation.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type SampleConservation");
        }

        public static readonly SampleConservationConverter Singleton = new SampleConservationConverter();
    }

    internal class ChecksumTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ChecksumType) || t == typeof(ChecksumType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "sha256")
            {
                return ChecksumType.Sha256;
            }
            throw new Exception("Cannot unmarshal type ChecksumType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ChecksumType)untypedValue;
            if (value == ChecksumType.Sha256)
            {
                serializer.Serialize(writer, "sha256");
                return;
            }
            throw new Exception("Cannot marshal type ChecksumType");
        }

        public static readonly ChecksumTypeConverter Singleton = new ChecksumTypeConverter();
    }

    internal class PurpleMinMaxValueCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<double>(reader);
            if (value >= 0)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type double");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (double)untypedValue;
            if (value >= 0)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type double");
        }

        public static readonly PurpleMinMaxValueCheckConverter Singleton = new PurpleMinMaxValueCheckConverter();
    }

    internal class FileTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FileType) || t == typeof(FileType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bam":
                    return FileType.Bam;
                case "bed":
                    return FileType.Bed;
                case "fastq":
                    return FileType.Fastq;
                case "vcf":
                    return FileType.Vcf;
            }
            throw new Exception("Cannot unmarshal type FileType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FileType)untypedValue;
            switch (value)
            {
                case FileType.Bam:
                    serializer.Serialize(writer, "bam");
                    return;
                case FileType.Bed:
                    serializer.Serialize(writer, "bed");
                    return;
                case FileType.Fastq:
                    serializer.Serialize(writer, "fastq");
                    return;
                case FileType.Vcf:
                    serializer.Serialize(writer, "vcf");
                    return;
            }
            throw new Exception("Cannot marshal type FileType");
        }

        public static readonly FileTypeConverter Singleton = new FileTypeConverter();
    }

    internal class ReadOrderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReadOrder) || t == typeof(ReadOrder?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "R1":
                    return ReadOrder.R1;
                case "R2":
                    return ReadOrder.R2;
            }
            throw new Exception("Cannot unmarshal type ReadOrder");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ReadOrder)untypedValue;
            switch (value)
            {
                case ReadOrder.R1:
                    serializer.Serialize(writer, "R1");
                    return;
                case ReadOrder.R2:
                    serializer.Serialize(writer, "R2");
                    return;
            }
            throw new Exception("Cannot marshal type ReadOrder");
        }

        public static readonly ReadOrderConverter Singleton = new ReadOrderConverter();
    }

    internal class FluffyMinMaxValueCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<double>(reader);
            if (value >= 0 && value <= 100)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type double");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (double)untypedValue;
            if (value >= 0 && value <= 100)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type double");
        }

        public static readonly FluffyMinMaxValueCheckConverter Singleton = new FluffyMinMaxValueCheckConverter();
    }

    internal class ReferenceGenomeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReferenceGenome) || t == typeof(ReferenceGenome?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "GRCh37":
                    return ReferenceGenome.GrCh37;
                case "GRCh38":
                    return ReferenceGenome.GrCh38;
            }
            throw new Exception("Cannot unmarshal type ReferenceGenome");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ReferenceGenome)untypedValue;
            switch (value)
            {
                case ReferenceGenome.GrCh37:
                    serializer.Serialize(writer, "GRCh37");
                    return;
                case ReferenceGenome.GrCh38:
                    serializer.Serialize(writer, "GRCh38");
                    return;
            }
            throw new Exception("Cannot marshal type ReferenceGenome");
        }

        public static readonly ReferenceGenomeConverter Singleton = new ReferenceGenomeConverter();
    }

    internal class TentacledMinMaxValueCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<double>(reader);
            if (value >= 0 && value <= 1)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type double");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (double)untypedValue;
            if (value >= 0 && value <= 1)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type double");
        }

        public static readonly TentacledMinMaxValueCheckConverter Singleton = new TentacledMinMaxValueCheckConverter();
    }

    internal class SequenceSubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SequenceSubtype) || t == typeof(SequenceSubtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "germline":
                    return SequenceSubtype.Germline;
                case "other":
                    return SequenceSubtype.Other;
                case "somatic":
                    return SequenceSubtype.Somatic;
                case "unknown":
                    return SequenceSubtype.Unknown;
            }
            throw new Exception("Cannot unmarshal type SequenceSubtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SequenceSubtype)untypedValue;
            switch (value)
            {
                case SequenceSubtype.Germline:
                    serializer.Serialize(writer, "germline");
                    return;
                case SequenceSubtype.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case SequenceSubtype.Somatic:
                    serializer.Serialize(writer, "somatic");
                    return;
                case SequenceSubtype.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type SequenceSubtype");
        }

        public static readonly SequenceSubtypeConverter Singleton = new SequenceSubtypeConverter();
    }

    internal class SequenceTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SequenceType) || t == typeof(SequenceType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "dna":
                    return SequenceType.Dna;
                case "rna":
                    return SequenceType.Rna;
            }
            throw new Exception("Cannot unmarshal type SequenceType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SequenceType)untypedValue;
            switch (value)
            {
                case SequenceType.Dna:
                    serializer.Serialize(writer, "dna");
                    return;
                case SequenceType.Rna:
                    serializer.Serialize(writer, "rna");
                    return;
            }
            throw new Exception("Cannot marshal type SequenceType");
        }

        public static readonly SequenceTypeConverter Singleton = new SequenceTypeConverter();
    }

    internal class SequencingLayoutConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SequencingLayout) || t == typeof(SequencingLayout?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "other":
                    return SequencingLayout.Other;
                case "paired-end":
                    return SequencingLayout.PairedEnd;
                case "reverse":
                    return SequencingLayout.Reverse;
                case "single-end":
                    return SequencingLayout.SingleEnd;
            }
            throw new Exception("Cannot unmarshal type SequencingLayout");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SequencingLayout)untypedValue;
            switch (value)
            {
                case SequencingLayout.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case SequencingLayout.PairedEnd:
                    serializer.Serialize(writer, "paired-end");
                    return;
                case SequencingLayout.Reverse:
                    serializer.Serialize(writer, "reverse");
                    return;
                case SequencingLayout.SingleEnd:
                    serializer.Serialize(writer, "single-end");
                    return;
            }
            throw new Exception("Cannot marshal type SequencingLayout");
        }

        public static readonly SequencingLayoutConverter Singleton = new SequencingLayoutConverter();
    }

    internal class MethodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Method) || t == typeof(Method?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bioinformatics":
                    return Method.Bioinformatics;
                case "other":
                    return Method.Other;
                case "pathology":
                    return Method.Pathology;
                case "unknown":
                    return Method.Unknown;
            }
            throw new Exception("Cannot unmarshal type Method");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Method)untypedValue;
            switch (value)
            {
                case Method.Bioinformatics:
                    serializer.Serialize(writer, "bioinformatics");
                    return;
                case Method.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case Method.Pathology:
                    serializer.Serialize(writer, "pathology");
                    return;
                case Method.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type Method");
        }

        public static readonly MethodConverter Singleton = new MethodConverter();
    }

    internal class DomainConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Domain) || t == typeof(Domain?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "caseIdentification":
                    return Domain.CaseIdentification;
                case "mvSequencing":
                    return Domain.MvSequencing;
                case "reIdentification":
                    return Domain.ReIdentification;
            }
            throw new Exception("Cannot unmarshal type Domain");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Domain)untypedValue;
            switch (value)
            {
                case Domain.CaseIdentification:
                    serializer.Serialize(writer, "caseIdentification");
                    return;
                case Domain.MvSequencing:
                    serializer.Serialize(writer, "mvSequencing");
                    return;
                case Domain.ReIdentification:
                    serializer.Serialize(writer, "reIdentification");
                    return;
            }
            throw new Exception("Cannot marshal type Domain");
        }

        public static readonly DomainConverter Singleton = new DomainConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "deny":
                    return TypeEnum.Deny;
                case "permit":
                    return TypeEnum.Permit;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Deny:
                    serializer.Serialize(writer, "deny");
                    return;
                case TypeEnum.Permit:
                    serializer.Serialize(writer, "permit");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class RelationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Relation) || t == typeof(Relation?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "brother":
                    return Relation.Brother;
                case "child":
                    return Relation.Child;
                case "father":
                    return Relation.Father;
                case "index":
                    return Relation.Index;
                case "mother":
                    return Relation.Mother;
                case "other":
                    return Relation.Other;
                case "sister":
                    return Relation.Sister;
            }
            throw new Exception("Cannot unmarshal type Relation");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Relation)untypedValue;
            switch (value)
            {
                case Relation.Brother:
                    serializer.Serialize(writer, "brother");
                    return;
                case Relation.Child:
                    serializer.Serialize(writer, "child");
                    return;
                case Relation.Father:
                    serializer.Serialize(writer, "father");
                    return;
                case Relation.Index:
                    serializer.Serialize(writer, "index");
                    return;
                case Relation.Mother:
                    serializer.Serialize(writer, "mother");
                    return;
                case Relation.Other:
                    serializer.Serialize(writer, "other");
                    return;
                case Relation.Sister:
                    serializer.Serialize(writer, "sister");
                    return;
            }
            throw new Exception("Cannot marshal type Relation");
        }

        public static readonly RelationConverter Singleton = new RelationConverter();
    }

    internal class NoScopeJustificationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(NoScopeJustification) || t == typeof(NoScopeJustification?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "consent information cannot be submitted by LE due to technical reason":
                    return NoScopeJustification.TechnicalReason;
                case "consent is not implemented at LE due to organizational issues":
                    return NoScopeJustification.OrganizationalIssues;
                case "other patient-related reason":
                    return NoScopeJustification.OtherPatientRelatedReason;
                case "patient did not return consent documents":
                    return NoScopeJustification.PatientDidNotReturnConsentDocuments;
                case "patient refuses to sign consent":
                    return NoScopeJustification.PatientRefusesToSignConsent;
                case "patient unable to consent":
                    return NoScopeJustification.PatientUnableToConsent;
            }
            throw new Exception("Cannot unmarshal type NoScopeJustification");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (NoScopeJustification)untypedValue;
            switch (value)
            {
                case NoScopeJustification.TechnicalReason:
                    serializer.Serialize(writer, "consent information cannot be submitted by LE due to technical reason");
                    return;
                case NoScopeJustification.OrganizationalIssues:
                    serializer.Serialize(writer, "consent is not implemented at LE due to organizational issues");
                    return;
                case NoScopeJustification.OtherPatientRelatedReason:
                    serializer.Serialize(writer, "other patient-related reason");
                    return;
                case NoScopeJustification.PatientDidNotReturnConsentDocuments:
                    serializer.Serialize(writer, "patient did not return consent documents");
                    return;
                case NoScopeJustification.PatientRefusesToSignConsent:
                    serializer.Serialize(writer, "patient refuses to sign consent");
                    return;
                case NoScopeJustification.PatientUnableToConsent:
                    serializer.Serialize(writer, "patient unable to consent");
                    return;
            }
            throw new Exception("Cannot marshal type NoScopeJustification");
        }

        public static readonly NoScopeJustificationConverter Singleton = new NoScopeJustificationConverter();
    }

    internal class SchemaVersionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SchemaVersion) || t == typeof(SchemaVersion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "2025.0.1")
            {
                return SchemaVersion.The202501;
            }
            throw new Exception("Cannot unmarshal type SchemaVersion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SchemaVersion)untypedValue;
            if (value == SchemaVersion.The202501)
            {
                serializer.Serialize(writer, "2025.0.1");
                return;
            }
            throw new Exception("Cannot marshal type SchemaVersion");
        }

        public static readonly SchemaVersionConverter Singleton = new SchemaVersionConverter();
    }

    internal class CoverageTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CoverageType) || t == typeof(CoverageType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BEI":
                    return CoverageType.Bei;
                case "BG":
                    return CoverageType.Bg;
                case "GKV":
                    return CoverageType.Gkv;
                case "GPV":
                    return CoverageType.Gpv;
                case "PKV":
                    return CoverageType.Pkv;
                case "PPV":
                    return CoverageType.Ppv;
                case "SEL":
                    return CoverageType.Sel;
                case "SKT":
                    return CoverageType.Skt;
                case "SOZ":
                    return CoverageType.Soz;
                case "UNK":
                    return CoverageType.Unk;
            }
            throw new Exception("Cannot unmarshal type CoverageType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CoverageType)untypedValue;
            switch (value)
            {
                case CoverageType.Bei:
                    serializer.Serialize(writer, "BEI");
                    return;
                case CoverageType.Bg:
                    serializer.Serialize(writer, "BG");
                    return;
                case CoverageType.Gkv:
                    serializer.Serialize(writer, "GKV");
                    return;
                case CoverageType.Gpv:
                    serializer.Serialize(writer, "GPV");
                    return;
                case CoverageType.Pkv:
                    serializer.Serialize(writer, "PKV");
                    return;
                case CoverageType.Ppv:
                    serializer.Serialize(writer, "PPV");
                    return;
                case CoverageType.Sel:
                    serializer.Serialize(writer, "SEL");
                    return;
                case CoverageType.Skt:
                    serializer.Serialize(writer, "SKT");
                    return;
                case CoverageType.Soz:
                    serializer.Serialize(writer, "SOZ");
                    return;
                case CoverageType.Unk:
                    serializer.Serialize(writer, "UNK");
                    return;
            }
            throw new Exception("Cannot marshal type CoverageType");
        }

        public static readonly CoverageTypeConverter Singleton = new CoverageTypeConverter();
    }

    internal class DiseaseTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DiseaseType) || t == typeof(DiseaseType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "hereditary":
                    return DiseaseType.Hereditary;
                case "oncological":
                    return DiseaseType.Oncological;
                case "rare":
                    return DiseaseType.Rare;
            }
            throw new Exception("Cannot unmarshal type DiseaseType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DiseaseType)untypedValue;
            switch (value)
            {
                case DiseaseType.Hereditary:
                    serializer.Serialize(writer, "hereditary");
                    return;
                case DiseaseType.Oncological:
                    serializer.Serialize(writer, "oncological");
                    return;
                case DiseaseType.Rare:
                    serializer.Serialize(writer, "rare");
                    return;
            }
            throw new Exception("Cannot marshal type DiseaseType");
        }

        public static readonly DiseaseTypeConverter Singleton = new DiseaseTypeConverter();
    }

    internal class GenomicStudySubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GenomicStudySubtype) || t == typeof(GenomicStudySubtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "germline-only":
                    return GenomicStudySubtype.GermlineOnly;
                case "tumor+germline":
                    return GenomicStudySubtype.TumorGermline;
                case "tumor-only":
                    return GenomicStudySubtype.TumorOnly;
            }
            throw new Exception("Cannot unmarshal type GenomicStudySubtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GenomicStudySubtype)untypedValue;
            switch (value)
            {
                case GenomicStudySubtype.GermlineOnly:
                    serializer.Serialize(writer, "germline-only");
                    return;
                case GenomicStudySubtype.TumorGermline:
                    serializer.Serialize(writer, "tumor+germline");
                    return;
                case GenomicStudySubtype.TumorOnly:
                    serializer.Serialize(writer, "tumor-only");
                    return;
            }
            throw new Exception("Cannot marshal type GenomicStudySubtype");
        }

        public static readonly GenomicStudySubtypeConverter Singleton = new GenomicStudySubtypeConverter();
    }

    internal class GenomicStudyTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GenomicStudyType) || t == typeof(GenomicStudyType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "duo":
                    return GenomicStudyType.Duo;
                case "single":
                    return GenomicStudyType.Single;
                case "trio":
                    return GenomicStudyType.Trio;
            }
            throw new Exception("Cannot unmarshal type GenomicStudyType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GenomicStudyType)untypedValue;
            switch (value)
            {
                case GenomicStudyType.Duo:
                    serializer.Serialize(writer, "duo");
                    return;
                case GenomicStudyType.Single:
                    serializer.Serialize(writer, "single");
                    return;
                case GenomicStudyType.Trio:
                    serializer.Serialize(writer, "trio");
                    return;
            }
            throw new Exception("Cannot marshal type GenomicStudyType");
        }

        public static readonly GenomicStudyTypeConverter Singleton = new GenomicStudyTypeConverter();
    }

    internal class SubmissionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SubmissionType) || t == typeof(SubmissionType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "addition":
                    return SubmissionType.Addition;
                case "correction":
                    return SubmissionType.Correction;
                case "followup":
                    return SubmissionType.Followup;
                case "initial":
                    return SubmissionType.Initial;
                case "test":
                    return SubmissionType.Test;
            }
            throw new Exception("Cannot unmarshal type SubmissionType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SubmissionType)untypedValue;
            switch (value)
            {
                case SubmissionType.Addition:
                    serializer.Serialize(writer, "addition");
                    return;
                case SubmissionType.Correction:
                    serializer.Serialize(writer, "correction");
                    return;
                case SubmissionType.Followup:
                    serializer.Serialize(writer, "followup");
                    return;
                case SubmissionType.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case SubmissionType.Test:
                    serializer.Serialize(writer, "test");
                    return;
            }
            throw new Exception("Cannot marshal type SubmissionType");
        }

        public static readonly SubmissionTypeConverter Singleton = new SubmissionTypeConverter();
    }
}
