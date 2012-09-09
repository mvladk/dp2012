function getFrames()
	
	{
	var f = self;
	while (true)
		
		{
		if (f.name == 'vcCourseMain' || f.name == 'vcCommFrame')
			return;
		if (f.parent == f)
			{
			self.location.replace('/frames.asp?targetURL=' + escape(self.location));
			return
			}
		f = f.parent
		}
	
	}
//getFrames()