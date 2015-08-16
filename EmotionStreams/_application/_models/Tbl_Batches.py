# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models


class TblBatches(models.Model):
    id = models.BigIntegerField(primary_key=True)
    streams = models.TextField()

    class Meta:
        managed = False
        db_table = 'tbl_batches'