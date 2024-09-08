﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Enum;

public class ServiceRequest
{
    [Required]
    [Key]
    public int ServiceId { get; set; }

    [Required]
    public int AssetId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime ServiceRequestDate { get; set; }

    [Required]
    public IssueType Issue_Type { get; set; }

    [Required]
    public string? ServiceDescription { get; set; }

    [Required]
    public ServiceReqStatus ServiceReqStatus { get; set; }

    //Navigation Properties
    // 1 - 1 Relation

    public Asset? Asset { get; set; }

    public User? User { get; set; } 
}
