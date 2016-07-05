java_file = "#{Chef::Config['file_cache_path']}/#{node['quickbase-java']['rpm_file']}"
remote_file java_file do
  source node['quickbase-java']['jdk_url']
  checksum node['quickbase-java']['jdk_checksum']
  retries 5
end

rpm_package node['quickbase-java']['rpm_package_name'] do
  source java_file
end

if node['quickbase-java']['install-jce-us-policy-files']

  jce_file = "#{Chef::Config['file_cache_path']}/#{node['quickbase-java']['jce_policy_file']}"
  remote_file jce_file do
    source node['quickbase-java']['jce_url']
  end

  chef_gem 'zip' do
    compile_time false
  end

  ruby_block 'install_jce' do
    block do
    	require 'zip'
      Zip::ZipFile.open(jce_file) do |zipfile|
        zipfile.each do |entry|
          file = File.basename(entry.name) # Strip the leading UnlimitedJCEPolicyJDK8/ directory
          next unless File.extname(file) == ".jar" # Skip the leading dir and README; we just want the *.jar files
        	dest_file = File.join("/usr/java/#{node['quickbase-java']['rpm_package_name']}/jre/lib/security", file)
    	    entry.extract(dest_file) { true }
        end
      end
    end
  end

end

magic_shell_environment 'JAVA_HOME' do
  value "/usr/java/#{node['quickbase-java']['rpm_package_name']}/jre"
end
