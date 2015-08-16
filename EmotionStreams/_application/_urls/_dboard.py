from django.conf.urls import patterns
#from django.conf.urls import include
from django.conf.urls import url

#! views
from _application._views._dboard.GET import Dboard

urlpatterns = patterns('',
    url(r'^dboard/$', Dboard.as_view(), name='dboard_vw'),
)