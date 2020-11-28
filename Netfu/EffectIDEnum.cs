using System;

namespace WindowsApplication2
{
	// Token: 0x02000058 RID: 88
	public enum EffectIDEnum
	{
		// Token: 0x0400018A RID: 394
		None = -1,
		// Token: 0x0400018B RID: 395
		Teleport = 4,
		// Token: 0x0400018C RID: 396
		PushBack,
		// Token: 0x0400018D RID: 397
		PushFront,
		// Token: 0x0400018E RID: 398
		Transpose = 8,
		// Token: 0x0400018F RID: 399
		EsquiveDamageAndPusch,
		// Token: 0x04000190 RID: 400
		Porter = 50,
		// Token: 0x04000191 RID: 401
		Lancer,
		// Token: 0x04000192 RID: 402
		VolPM = 77,
		// Token: 0x04000193 RID: 403
		Add_PM,
		// Token: 0x04000194 RID: 404
		VolVie = 82,
		// Token: 0x04000195 RID: 405
		VolPA = 84,
		// Token: 0x04000196 RID: 406
		DamageLifeEau,
		// Token: 0x04000197 RID: 407
		DamageLifeTerre,
		// Token: 0x04000198 RID: 408
		DamageLifeAir,
		// Token: 0x04000199 RID: 409
		DamageLifeFeu,
		// Token: 0x0400019A RID: 410
		DamageLifeNeutre,
		// Token: 0x0400019B RID: 411
		VolEau = 91,
		// Token: 0x0400019C RID: 412
		VolTerre,
		// Token: 0x0400019D RID: 413
		VolAir,
		// Token: 0x0400019E RID: 414
		VolFeu,
		// Token: 0x0400019F RID: 415
		VolNeutre,
		// Token: 0x040001A0 RID: 416
		DamageEau,
		// Token: 0x040001A1 RID: 417
		DamageTerre,
		// Token: 0x040001A2 RID: 418
		DamageAir,
		// Token: 0x040001A3 RID: 419
		DamageFeu,
		// Token: 0x040001A4 RID: 420
		DamageNeutre,
		// Token: 0x040001A5 RID: 421
		RemovePA,
		// Token: 0x040001A6 RID: 422
		AddArmor = 105,
		// Token: 0x040001A7 RID: 423
		AddRenvoiDamage = 107,
		// Token: 0x040001A8 RID: 424
		AddDamageReflection = 107,
		// Token: 0x040001A9 RID: 425
		Heal,
		// Token: 0x040001AA RID: 426
		DamageLanceur,
		// Token: 0x040001AB RID: 427
		AddLife,
		// Token: 0x040001AC RID: 428
		AddPA,
		// Token: 0x040001AD RID: 429
		AddDamage,
		// Token: 0x040001AE RID: 430
		MultiplyDamage = 114,
		// Token: 0x040001AF RID: 431
		AddDamageCritic,
		// Token: 0x040001B0 RID: 432
		SubPO,
		// Token: 0x040001B1 RID: 433
		AddPO,
		// Token: 0x040001B2 RID: 434
		AddForce,
		// Token: 0x040001B3 RID: 435
		AddAgilite,
		// Token: 0x040001B4 RID: 436
		AddPABis,
		// Token: 0x040001B5 RID: 437
		AddDamage121,
		// Token: 0x040001B6 RID: 438
		AddEchecCritic,
		// Token: 0x040001B7 RID: 439
		AddChance,
		// Token: 0x040001B8 RID: 440
		AddPo136,
		// Token: 0x040001B9 RID: 441
		AddSagesse = 124,
		// Token: 0x040001BA RID: 442
		AddVitalite,
		// Token: 0x040001BB RID: 443
		AddIntelligence,
		// Token: 0x040001BC RID: 444
		RemovePM,
		// Token: 0x040001BD RID: 445
		AddPM,
		// Token: 0x040001BE RID: 446
		DegatPAusing = 131,
		// Token: 0x040001BF RID: 447
		DeleteAllBonus,
		// Token: 0x040001C0 RID: 448
		LosingPA,
		// Token: 0x040001C1 RID: 449
		LosingPM,
		// Token: 0x040001C2 RID: 450
		SubPO135,
		// Token: 0x040001C3 RID: 451
		AddPhysicalDamage = 137,
		// Token: 0x040001C4 RID: 452
		AddDamagePercent,
		// Token: 0x040001C5 RID: 453
		NextTour = 140,
		// Token: 0x040001C6 RID: 454
		AddDamagePhysic = 142,
		// Token: 0x040001C7 RID: 455
		AddPhysicalDamage142 = 142,
		// Token: 0x040001C8 RID: 456
		AddDamageMagic,
		// Token: 0x040001C9 RID: 457
		SubDamageBonus = 145,
		// Token: 0x040001CA RID: 458
		ChangeSkin = 149,
		// Token: 0x040001CB RID: 459
		Invisible,
		// Token: 0x040001CC RID: 460
		SubChance = 152,
		// Token: 0x040001CD RID: 461
		SubVitalite,
		// Token: 0x040001CE RID: 462
		SubAgilite,
		// Token: 0x040001CF RID: 463
		SubIntelligence,
		// Token: 0x040001D0 RID: 464
		SubSagesse,
		// Token: 0x040001D1 RID: 465
		SubForce,
		// Token: 0x040001D2 RID: 466
		AddPods,
		// Token: 0x040001D3 RID: 467
		SubPods,
		// Token: 0x040001D4 RID: 468
		AddEsquivePA,
		// Token: 0x040001D5 RID: 469
		AddEsquivePM,
		// Token: 0x040001D6 RID: 470
		SubEsquivePA,
		// Token: 0x040001D7 RID: 471
		SubEsquivePM,
		// Token: 0x040001D8 RID: 472
		SubDamage,
		// Token: 0x040001D9 RID: 473
		AddDamageBonusPercent,
		// Token: 0x040001DA RID: 474
		SubPA = 168,
		// Token: 0x040001DB RID: 475
		SubPM,
		// Token: 0x040001DC RID: 476
		const_82 = 171,
		// Token: 0x040001DD RID: 477
		SubDamageMagic,
		// Token: 0x040001DE RID: 478
		SubDamagePhysic,
		// Token: 0x040001DF RID: 479
		AddInitiative,
		// Token: 0x040001E0 RID: 480
		SubInitiative,
		// Token: 0x040001E1 RID: 481
		AddProspection,
		// Token: 0x040001E2 RID: 482
		SubProspection,
		// Token: 0x040001E3 RID: 483
		AddSoins,
		// Token: 0x040001E4 RID: 484
		SubSoins,
		// Token: 0x040001E5 RID: 485
		Clone,
		// Token: 0x040001E6 RID: 486
		Invoque,
		// Token: 0x040001E7 RID: 487
		AddInvocationMax,
		// Token: 0x040001E8 RID: 488
		AddReduceDamagePhysic,
		// Token: 0x040001E9 RID: 489
		AddReduceDamageMagic,
		// Token: 0x040001EA RID: 490
		SubDamageBonusPercent = 186,
		// Token: 0x040001EB RID: 491
		AddReduceDamagePourcentTerre = 210,
		// Token: 0x040001EC RID: 492
		AddReduceDamagePourcentEau,
		// Token: 0x040001ED RID: 493
		AddReduceDamagePourcentAir,
		// Token: 0x040001EE RID: 494
		AddReduceDamagePourcentFeu,
		// Token: 0x040001EF RID: 495
		AddReduceDamagePourcentNeutre,
		// Token: 0x040001F0 RID: 496
		SubReduceDamagePourcentTerre,
		// Token: 0x040001F1 RID: 497
		SubReduceDamagePourcentEau,
		// Token: 0x040001F2 RID: 498
		SubReduceDamagePourcentAir,
		// Token: 0x040001F3 RID: 499
		SubReduceDamagePourcentFeu,
		// Token: 0x040001F4 RID: 500
		SubReduceDamagePourcentNeutre,
		// Token: 0x040001F5 RID: 501
		AddDamagePiege = 225,
		// Token: 0x040001F6 RID: 502
		AddDamagePiegePercent = 225,
		// Token: 0x040001F7 RID: 503
		AddReduceDamageTerre = 240,
		// Token: 0x040001F8 RID: 504
		AddReduceDamageEau,
		// Token: 0x040001F9 RID: 505
		AddReduceDamageAir,
		// Token: 0x040001FA RID: 506
		AddReduceDamageFeu,
		// Token: 0x040001FB RID: 507
		AddReduceDamageNeutre,
		// Token: 0x040001FC RID: 508
		SubReduceDamageTerre,
		// Token: 0x040001FD RID: 509
		SubReduceDamageEau,
		// Token: 0x040001FE RID: 510
		SubReduceDamageAir,
		// Token: 0x040001FF RID: 511
		SubReduceDamageFeu,
		// Token: 0x04000200 RID: 512
		SubReduceDamageNeutre,
		// Token: 0x04000201 RID: 513
		AddReduceDamagePourcentPvPTerre,
		// Token: 0x04000202 RID: 514
		AddReduceDamagePourcentPvPEau,
		// Token: 0x04000203 RID: 515
		AddReduceDamagePourcentPvPAir,
		// Token: 0x04000204 RID: 516
		AddReduceDamagePourcentPvPFeu,
		// Token: 0x04000205 RID: 517
		AddReduceDamagePourcentPvpNeutre,
		// Token: 0x04000206 RID: 518
		SubReduceDamagePourcentPvPEau,
		// Token: 0x04000207 RID: 519
		SubReduceDamagePourcentPvPTerre,
		// Token: 0x04000208 RID: 520
		SubReduceDamagePourcentPvPAir,
		// Token: 0x04000209 RID: 521
		SubReduceDamagePourcentPvPFeu,
		// Token: 0x0400020A RID: 522
		SubReduceDamagePourcentPvpNeutre,
		// Token: 0x0400020B RID: 523
		AddReduceDamagePvPTerre,
		// Token: 0x0400020C RID: 524
		AddReduceDamagePvPEau,
		// Token: 0x0400020D RID: 525
		AddReduceDamagePvPAir,
		// Token: 0x0400020E RID: 526
		AddReduceDamagePvPFeu,
		// Token: 0x0400020F RID: 527
		AddReduceDamagePvPNeutre,
		// Token: 0x04000210 RID: 528
		AddArmorBis,
		// Token: 0x04000211 RID: 529
		AddSpellPo = 281,
		// Token: 0x04000212 RID: 530
		SubPacost = 285,
		// Token: 0x04000213 RID: 531
		Reductdelais,
		// Token: 0x04000214 RID: 532
		AddCC,
		// Token: 0x04000215 RID: 533
		DisabledLineofvision,
		// Token: 0x04000216 RID: 534
		Addlaunchcount = 290,
		// Token: 0x04000217 RID: 535
		SpellBoost = 293,
		// Token: 0x04000218 RID: 536
		UseTrap = 400,
		// Token: 0x04000219 RID: 537
		UseGlyph,
		// Token: 0x0400021A RID: 538
		VolPA440 = 440,
		// Token: 0x0400021B RID: 539
		VolPM441,
		// Token: 0x0400021C RID: 540
		AddSpell = 604,
		// Token: 0x0400021D RID: 541
		AddCharactForce = 607,
		// Token: 0x0400021E RID: 542
		AddCharactChance,
		// Token: 0x0400021F RID: 543
		AddCharactAgilite,
		// Token: 0x04000220 RID: 544
		AddCharactVitalite,
		// Token: 0x04000221 RID: 545
		AddCharactIntelligence,
		// Token: 0x04000222 RID: 546
		AddCharactPoint,
		// Token: 0x04000223 RID: 547
		AddSpellPoint,
		// Token: 0x04000224 RID: 548
		PierreAme = 623,
		// Token: 0x04000225 RID: 549
		DoNothing = 666,
		// Token: 0x04000226 RID: 550
		Incarnation = 669,
		// Token: 0x04000227 RID: 551
		DamageLife = 672,
		// Token: 0x04000228 RID: 552
		AddCharactSagesse = 678,
		// Token: 0x04000229 RID: 553
		Mobskilled = 717,
		// Token: 0x0400022A RID: 554
		Erosion = 776,
		// Token: 0x0400022B RID: 555
		LaisseSpirituel = 780,
		// Token: 0x0400022C RID: 556
		MinimizeJet,
		// Token: 0x0400022D RID: 557
		MaximiseJet,
		// Token: 0x0400022E RID: 558
		PushFear,
		// Token: 0x0400022F RID: 559
		Raulback,
		// Token: 0x04000230 RID: 560
		LaunchOtherSpell = 787,
		// Token: 0x04000231 RID: 561
		AddChatiment,
		// Token: 0x04000232 RID: 562
		LifeFami = 800,
		// Token: 0x04000233 RID: 563
		EtatFami = 806,
		// Token: 0x04000234 RID: 564
		LastEat = 808,
		// Token: 0x04000235 RID: 565
		AddState = 950,
		// Token: 0x04000236 RID: 566
		LostState,
		// Token: 0x04000237 RID: 567
		LivingGfxId = 970,
		// Token: 0x04000238 RID: 568
		LivingMood,
		// Token: 0x04000239 RID: 569
		LivingSkin,
		// Token: 0x0400023A RID: 570
		LivingType,
		// Token: 0x0400023B RID: 571
		LivingXp,
		// Token: 0x0400023C RID: 572
		CanBeExchange = 983,
		// Token: 0x0400023D RID: 573
		MountOwner = 995,
		// Token: 0x0400023E RID: 574
		AddDamagePercent1054 = 1054,
		// Token: 0x0400023F RID: 575
		AddVitalitePercent = 1078
	}
}
