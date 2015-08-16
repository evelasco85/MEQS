# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models

#! relation
from _application._models.Tbl_Batches import TblBatches


class TblStreams(models.Model):
    id = models.BigIntegerField(primary_key=True)
    stream_id = models.BigIntegerField()
    batch = models.ForeignKey(TblBatches, models.DO_NOTHING)
    profile_pic = models.TextField()
    profile_id = models.BigIntegerField()
    profile_name = models.TextField()
    text = models.TextField()
    time = models.CharField(max_length=200)

    class Meta:
        managed = False
        db_table = 'tbl_streams'