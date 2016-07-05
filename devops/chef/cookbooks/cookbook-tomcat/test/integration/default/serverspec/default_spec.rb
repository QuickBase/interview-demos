require 'serverspec_helper'

describe command('/opt/tomcat/bin/version.sh') do
  its(:stdout) { should match('Server number:  8.0.36.0') }
end
